using UnityEngine;
using KartRace.Application;
using KartRace.InterfaceAdapters;

namespace KartRace.Installers
{
    public class InstallerPlayerPrefs : MonoBehaviour
    {
        private void Awake()
        {
            var playerPrefsAdapter = new PlayerPrefAdapter();
            Application.ServiceLocator.Instance.RegisterService<IDataSaverPlayerPref>( playerPrefsAdapter );
            var matchDataSaverPlayerPrefs = new KartRace.Matchs.Domain.UseCase.MatchDataSaverPlayerPrefs();
            Application.ServiceLocator.Instance.RegisterService<KartRace.Matchs.Domain.Data.IMatchDataSaver>( matchDataSaverPlayerPrefs );
        }
    }
}