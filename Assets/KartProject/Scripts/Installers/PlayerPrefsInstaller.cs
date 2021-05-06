using UnityEngine;
using KartRace.Application;
using KartRace.InterfaceAdapters;

namespace KartRace.Installers
{
    public class PlayerPrefsInstaller : MonoBehaviour
    {
        private void Awake()
        {
            PlayerPrefAdapterRegisterService();
            MatchDataSaverAsPlayerPrefRegisterService();
        }

        public void PlayerPrefAdapterRegisterService()
        {
            var playerPrefsAdapter = new PlayerPrefAdapter();
            ServiceLocator.Instance.RegisterService<IDataSaverPlayerPref>( playerPrefsAdapter );
        }

        public void MatchDataSaverAsPlayerPrefRegisterService()
        {
            var matchDataSaverPlayerPrefs = new Matchs.Domain.UseCase.MatchDataSaverPlayerPrefs();
            ServiceLocator.Instance.RegisterService<Matchs.Domain.Data.IMatchDataSaver>( matchDataSaverPlayerPrefs );
        }

    }
}