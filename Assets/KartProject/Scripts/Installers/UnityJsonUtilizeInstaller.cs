namespace KartRace.Installers
{
    public class UnityJsonUtilizeInstaller : UnityEngine.MonoBehaviour
    {
        private void Awake()
        {
            UnityJsonUtilizeAdapterRegisterService();
        }

        public void UnityJsonUtilizeAdapterRegisterService()
        {
            var UnityJsonUtilizeAdapter = new InterfaceAdapters.UnityJsonUtilizeAdapter();
            Application.ServiceLocator.Instance.RegisterService<Application.IParser>( UnityJsonUtilizeAdapter );
        }
    }
}
    