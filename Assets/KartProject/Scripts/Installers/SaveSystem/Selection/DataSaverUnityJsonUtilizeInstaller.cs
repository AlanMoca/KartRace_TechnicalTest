using UnityEngine;

namespace KartRace.Installers.SaveSystem.Selection
{
    [RequireComponent( typeof( UnityJsonUtilizeInstaller ) )]
    public class DataSaverUnityJsonUtilizeInstaller : MonoBehaviour, IDataSaverInstaller
    {
        private void Awake()
        {
            MatchDataSaverRegisterService();
        }

        public void MatchDataSaverRegisterService()
        {
            var matchDataSaverPlayerPrefs = new Matchs.Domain.UseCase.MatchDataSaverJSON();
            Application.ServiceLocator.Instance.RegisterService<Matchs.Domain.Entity.IMatchDataSaver>( matchDataSaverPlayerPrefs );
        }

        public void PlayerDataSaverRegisterService()
        {
            throw new System.NotImplementedException();
        }
    }
}

