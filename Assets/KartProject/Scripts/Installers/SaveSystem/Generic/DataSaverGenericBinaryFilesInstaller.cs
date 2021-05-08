namespace KartRace.Installers.SaveSystem.Generic
{
    public class DataSaverGenericBinaryFilesInstaller : UnityEngine.MonoBehaviour
    {
        private void Awake()
        {
            DataSaverAsBinaryFileRegisterService();
        }

        public void DataSaverAsBinaryFileRegisterService()
        {
            var dataSaverBinaryFile = new SaveSystems.Domain.UseCase.DataSaverGenericBinaryFiles();
            Application.ServiceLocator.Instance.RegisterService<SaveSystems.Domain.Entity.IDataSaver>( dataSaverBinaryFile );
        }
    }
}
