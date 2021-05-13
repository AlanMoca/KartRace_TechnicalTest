using UnityEngine;

namespace KartRace.Installers.SaveSystem.Generic
{
    [RequireComponent( typeof( UnityJsonUtilizeInstaller ) )]
    public class DataSaverGenericJsonUtilizeInstaller : UnityEngine.MonoBehaviour
    {
        private void Awake()
        {
            DataSaverAsJsonUtilizeRegisterService();
        }

        public void DataSaverAsJsonUtilizeRegisterService()
        {
            var dataSaverJsonUtilize = new SaveSystems.Domain.UseCase.DataSaverGenericJsonUtilize();
            Application.ServiceLocator.Instance.RegisterService<SaveSystems.Domain.Entity.IDataSaver>( dataSaverJsonUtilize );
        }
    }
}

