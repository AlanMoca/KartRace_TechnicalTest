namespace KartRace.Installers
{
    public class PlayerPrefsInstaller : UnityEngine.MonoBehaviour
    {
        private void Awake()
        {
            PlayerPrefAdapterRegisterService();
        }

        public void PlayerPrefAdapterRegisterService()
        {
            var playerPrefsAdapter = new InterfaceAdapters.PlayerPrefAdapter();
            Application.ServiceLocator.Instance.RegisterService<Application.IDataSaverPlayerPref>( playerPrefsAdapter );
        }
    }
}