namespace KartRace.Installers
{
    public class FileSystemIOInstaller : UnityEngine.MonoBehaviour
    {
        private void Awake()
        {
            fileSystemIOAdapterRegisterService();
        }

        public void fileSystemIOAdapterRegisterService()
        {
            var fileSystemIOAdapter = new InterfaceAdapters.FileSystemIOAdapter();
            Application.ServiceLocator.Instance.RegisterService<Application.IFile>( fileSystemIOAdapter );
        }
    }
}