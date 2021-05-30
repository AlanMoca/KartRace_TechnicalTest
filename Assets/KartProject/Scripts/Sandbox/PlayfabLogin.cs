using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

namespace KartRace.CloudService.Domain.UseCase
{
    public class PlayfabLogin : Entity.ILogin
    {
        private event Action OnLoginSuccess;

        public void Register( string email, string password )
        {
            
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
            PlayFabClientAPI.LoginWithEmailAddress( request, OnLoginSuccessful, OnError );
        }

        public void Logout()
        {
            PlayFabClientAPI.ForgetAllCredentials();
            var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( $"You are not logged" );
        }

        public bool IsLoggedIn()
        {
            return PlayFabClientAPI.IsClientLoggedIn();
        }

        private void OnRegisterSuccess( RegisterPlayFabUserResult userResult )
        {
            var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( $"Registered and logged in!" );
        }

        private void OnLoginSuccessful( LoginResult userResult )
        {
            OnLoginSuccess?.Invoke();
            var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( $"Logged in!" );
        }

        private void OnError( PlayFabError error )
        {
            var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
            messageService.MessageToShow( error.ErrorMessage );
            Debug.Log( error.GenerateErrorReport() );
        }

        public void SubscribeOnLoginSuccessEvent( Action _OnLoginSuccess )
        {
            OnLoginSuccess += _OnLoginSuccess;
        }

        public void UnsubscribeOnLoginSuccessEvent( Action _OnLoginSuccess )
        {
            OnLoginSuccess -= _OnLoginSuccess;
        }
    }
}

