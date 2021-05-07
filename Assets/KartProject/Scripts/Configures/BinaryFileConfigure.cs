using UnityEngine;
using KartRace.Application;

namespace KartRace.Installers
{
    [RequireComponent( typeof( Configures.MatchConfigureGenericBinaryFormatter ) )]
    public class BinaryFileConfigure : MonoBehaviour
    {
        private Application.UseCase.DataSaverBinaryFile dataSaverBinaryFile;

        private void Awake()
        {
            DataSaverAsBinaryFileRegisterService();
        }

        public void DataSaverAsBinaryFileRegisterService()
        {
            dataSaverBinaryFile = new Application.UseCase.DataSaverBinaryFile();
            ServiceLocator.Instance.RegisterService<Application.Entity.IDataSaver>( dataSaverBinaryFile );
        }

    }
}
