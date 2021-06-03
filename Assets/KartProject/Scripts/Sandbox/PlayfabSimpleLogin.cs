using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using KartRace.Views.MainMenu;
using System;

namespace KartRace.CloudService.Domain.UseCase
{
    public class PlayfabSimpleLogin : Entity.ILogin
    {
        public void Login()
        {
            var request = new LoginWithCustomIDRequest {
                CustomId = SystemInfo.deviceUniqueIdentifier,
                CreateAccount = true
            };

            PlayFabClientAPI.LoginWithCustomID( request, OnSuccess, OnError );
        }

        private void OnSuccess( LoginResult result )
        {
            Debug.Log( "Successful login/account create!" );
        }

        private void OnError( PlayFabError error )
        {
            Debug.Log( "Error while logging in/creating account!" );
            Debug.Log( error.GenerateErrorReport() );
        }

        public void Register( string email, string password )
        {
            throw new System.NotImplementedException();
        }

        public void Login( string email, string password )
        {
            throw new System.NotImplementedException();
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public bool IsLoggedIn()
        {
            throw new System.NotImplementedException();
        }

        public void SubscribeOnLoginSuccessEvent( Action _OnLoginSuccess )
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeOnLoginSuccessEvent( Action _OnLoginSuccess )
        {
            throw new NotImplementedException();
        }

        public void SubscribeOnRegisterSuccessEvent( Action _OnRegisterSuccess )
        {
            throw new NotImplementedException();
        }

        public void UnsubscribeOnRegisterSuccessEvent( Action _OnRegisterSuccess )
        {
            throw new NotImplementedException();
        }
    }
}

