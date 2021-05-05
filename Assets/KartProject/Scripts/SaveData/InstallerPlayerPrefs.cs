using UnityEngine;
using KartRace.Application;

namespace KartRace.InterfaceAdapters
{
    public class InstallerPlayerPrefs : MonoBehaviour
    {
        private void Awake()
        {
            var playerPrefsAdapter = new PlayerPrefAdapter();
            KartRace.Players.ServiceLocator.Instance.RegisterService<IDataSaverPlayerPref>( playerPrefsAdapter );
            var matchDataSaverPlayerPrefs = new KartRace.Matchs.MatchDataSaverPlayerPrefs();
            KartRace.Players.ServiceLocator.Instance.RegisterService<KartRace.Matchs.IMatchDataSaver>( matchDataSaverPlayerPrefs );
        }
    }
}