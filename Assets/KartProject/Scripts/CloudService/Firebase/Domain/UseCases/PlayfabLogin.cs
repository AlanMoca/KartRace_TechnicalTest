using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

namespace KartRace.CloudService.Domain.UseCase
{
    public class PlayfabLogin : Entity.ILogin
    {
        private event Action OnLoginSuccessEvent;
        private event Action OnRegisterSuccessEvent;
        private event Action OnLogoutSuccessEvent;

        public void Register( string email, string password )
        {
            OnRegisterSuccessEvent?.Invoke();

            if( password.Length < 6 )
            {
                var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
                messageService.MessageToShow( $"Password too short! Try again." );
                return;
            }

            var request = new RegisterPlayFabUserRequest {
                Email = email,
                Password = password,
                RequireBothUsernameAndEmail = false
            };
            PlayFabClientAPI.RegisterPlayFabUser( request, OnRegisterSuccess, OnError );
            //Aquí debería tener un tipo de suscripcción a algún envento de login para que cuando el usuario este loggeado o se logge, automáticamente mande el raise y desaparezca la pantalla de login y ponga la otra.
            //PlayFab.Events.PlayFabEventsAPI.IsEntityLoggedIn.OnRegisterSuccess
        }

        public void Login( string email, string password )
        {
            if( PlayFabClientAPI.IsClientLoggedIn() )
            {
                var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
                messageService.MessageToShow( $"You are login" );
                return;
            }

            var request = new LoginWithEmailAddressRequest {
                Email = email,
                Password = password
            };
            PlayFabClientAPI.LoginWithEmailAddress( request, OnLoginSuccess, OnError );
        }

        public void ResetPasswordButton( string email )
        {
            var request = new SendAccountRecoveryEmailRequest {
                Email = email,
                TitleId = "16241"                                                               //Is from the game playfab in my backend
            };
            PlayFabClientAPI.SendAccountRecoveryEmail( request, OnPasswordReset, OnError );
        }

        public void Logout()
        {
            OnLogoutSuccessEvent?.Invoke();
            PlayFabClientAPI.ForgetAllCredentials();
            var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( $"You are not logged" );
        }

        public bool IsLoggedIn()
        {
            return PlayFabClientAPI.IsClientLoggedIn();
        }

        private void OnRegisterSuccess( RegisterPlayFabUserResult result )
        {
            var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( $"Registered and logged in!" );
        }

        private void OnLoginSuccess( LoginResult result )
        {
            OnLoginSuccessEvent?.Invoke();
            var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( $"Logged in!" );
        }

        private void OnPasswordReset( SendAccountRecoveryEmailResult result )
        {
            var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( $"Password reset. Mail sent!" );
        }

        private void OnError( PlayFabError error )
        {
            var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( error.ErrorMessage );
            Debug.Log( error.GenerateErrorReport() );
        }

        public void SubscribeOnRegisterSuccessEvent( Action _OnRegisterSuccess )
        {
            OnRegisterSuccessEvent += _OnRegisterSuccess;
        }

        public void UnsubscribeOnRegisterSuccessEvent( Action _OnRegisterSuccess )
        {
            OnRegisterSuccessEvent -= _OnRegisterSuccess;
        }

        public void SubscribeOnLogoutSuccessEvent( Action _OnRegisterSuccess )
        {
            OnLogoutSuccessEvent += _OnRegisterSuccess;
        }

        public void UnsubscribeOnLogoutSuccessEvent( Action _OnRegisterSuccess )
        {
            OnLogoutSuccessEvent -= _OnRegisterSuccess;
        }

        public void SubscribeOnLoginSuccessEvent( Action _OnLoginSuccess )
        {
            OnLoginSuccessEvent += _OnLoginSuccess;
        }

        public void UnsubscribeOnLoginSuccessEvent( Action _OnLoginSuccess )
        {
            OnLoginSuccessEvent -= _OnLoginSuccess;
        }
    }
}

