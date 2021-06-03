namespace KartRace.CloudService.Domain.Entity
{
    public interface ILogin
    {
        void Register( string email, string password  );      //Registra y loggea
        void Login( string email, string password );
        void Logout();
        bool IsLoggedIn();
        public void SubscribeOnLoginSuccessEvent( System.Action _OnLoginSuccess );
        public void UnsubscribeOnLoginSuccessEvent( System.Action _OnLoginSuccess );
        public void SubscribeOnRegisterSuccessEvent( System.Action _OnRegisterSuccess );

        public void UnsubscribeOnRegisterSuccessEvent( System.Action _OnRegisterSuccess );
    }
}
