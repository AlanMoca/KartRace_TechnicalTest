using KartRace.Views.MainMenu;
using System;
using UnityEngine;

namespace KartRace.CloudService.Domain.UseCase
{
    public class PlayfabServiceFacade : Entity.ICloudService
    {
        private Entity.ILogin login;
        private ILeaderboard leaderboard;

        public PlayfabServiceFacade( Entity.ILogin _login, ILeaderboard _leaderboard)
        {
            login = _login;
            leaderboard = _leaderboard;
        }

        public void Register( string email, string password )
        {
            login.Register( email, password );
        }

        public void Login( string email, string password )
        {
            login.Login( email, password );
        }

        public void Logout()
        {
            login.Logout();
        }

        public void SendDataToLeaderboard( int score )
        {
            leaderboard.SendDataToLeaderboard( score );
        }

        public bool IsLoggedIn()
        {
            return login.IsLoggedIn();            
        }

        public void SubscribeOnLoginSuccessEvent( Action _OnLoginSuccess )
        {
            login.SubscribeOnLoginSuccessEvent( _OnLoginSuccess );
        }

        public void UnsubscribeOnLoginSuccessEvent( Action _OnLoginSuccess )
        {
            login.UnsubscribeOnLoginSuccessEvent( _OnLoginSuccess );
        }
    }
}