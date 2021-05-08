using UnityEngine;

namespace KartRace.Installers.SaveSystem.Selection
{
    [RequireComponent(typeof(PlayerPrefsInstaller))]
    public class DataSaverPlayerPrefsInstaller : MonoBehaviour, IDataSaverInstaller
    {
        private void Awake()
        {
            MatchDataSaverRegisterService();
        }

        public void MatchDataSaverRegisterService()
        {
            var matchDataSaverPlayerPrefs = new Matchs.Domain.UseCase.MatchDataSaverPlayerPrefs();
            Application.ServiceLocator.Instance.RegisterService<Matchs.Domain.Entity.IMatchDataSaver>( matchDataSaverPlayerPrefs );
        }

        public void PlayerDataSaverRegisterService()
        {
            throw new System.NotImplementedException();
        }
    }
}
