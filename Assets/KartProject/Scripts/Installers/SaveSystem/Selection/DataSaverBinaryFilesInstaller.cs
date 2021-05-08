using UnityEngine;

namespace KartRace.Installers.SaveSystem.Selection
{
    public class DataSaverBinaryFilesInstaller : MonoBehaviour, IDataSaverInstaller
    {
        private void Awake()
        {
            MatchDataSaverRegisterService();
            GetComponent<DataSaverBinaryFilesInstaller>().enabled = false;
        }

        public void MatchDataSaverRegisterService()
        {
            var matchDataSaverBinaryFile = new Matchs.Domain.UseCase.MatchDataSaverBinaryFiles();
            Application.ServiceLocator.Instance.RegisterService<Matchs.Domain.Entity.IMatchDataSaver>( matchDataSaverBinaryFile );
        }

        public void PlayerDataSaverRegisterService()
        {
            throw new System.NotImplementedException();
        }
    }
}