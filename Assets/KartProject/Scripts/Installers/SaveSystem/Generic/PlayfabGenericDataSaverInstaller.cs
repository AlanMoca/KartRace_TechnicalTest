//No funciona ya que dada la estructura que stamos usando, no se puede retornar un valor dentro de un request.
namespace KartRace.Installers.SaveSystem.Generic
{
    public class PlayfabGenericDataSaverInstaller : UnityEngine.MonoBehaviour
    {
        private void Awake()
        {
            DataSaverAsPlayfabRegisterService();
        }

        public void DataSaverAsPlayfabRegisterService()
        {
            var dataSaverBinaryFile = new SaveSystems.Domain.UseCase.PlayfabGenericDataSaver();
            Application.ServiceLocator.Instance.RegisterService<SaveSystems.Domain.Entity.IDataSaver>( dataSaverBinaryFile );
        }
    }
}