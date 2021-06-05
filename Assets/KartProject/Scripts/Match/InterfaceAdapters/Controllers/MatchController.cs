using UnityEngine;
using KartRace.Matchs.Domain.Entity;

namespace KartRace.Matchs.InterfaceAdapters.Controller
{
    public class MatchController : MonoBehaviour
    {
        private SaveSystems.Domain.Entity.IDataSaver genericDataSaver;
        private IMatchDataSaver matchDataSaver;
        private MatchData matchData;

        private bool useCloudSaveSystem;
        private bool useGenericSaveSystem;
        private bool useSpecificSaveSystem;

        public void Configure( IMatchDataSaver _matchDataSaver )
        {
            matchDataSaver = _matchDataSaver;
            useCloudSaveSystem = true;
            useGenericSaveSystem = false;
            useSpecificSaveSystem = false;
        }

        public void Configure( SaveSystems.Domain.Entity.IDataSaver _dataSaver, MatchData _matchData )
        {
            genericDataSaver = _dataSaver;
            matchData = _matchData;
            useGenericSaveSystem = true;
            useSpecificSaveSystem = false;
        }

        public void Configure( IMatchDataSaver _matchDataSaver, MatchData _matchData, bool isUsedCloudPlatform )
        {
            matchDataSaver = _matchDataSaver;
            matchData = _matchData;
            if( isUsedCloudPlatform )
            {
                useCloudSaveSystem = true;
                useGenericSaveSystem = false;
                useSpecificSaveSystem = false;
                return;
            }
            useCloudSaveSystem = false;
            useGenericSaveSystem = false;
            useSpecificSaveSystem = true;
        }

        public bool GetIfUsingCloudSaveSystem()
        {
            return useCloudSaveSystem;
        }

        public void SaveMatchData()
        {
            if( useGenericSaveSystem )
                genericDataSaver.SaveData<MatchData>( matchData, "matchData" );
            if( useSpecificSaveSystem )
                matchDataSaver.SaveMatchData( matchData );
        }

        public void AddNumberOfRaces()
        {
            matchData.AddNumberOfRaces();
        }

        public int GetNumberOfRaces()
        {
            return matchData.GetNumberOfRaces();
        }

        public void AddRacesWon()
        {
            matchData.AddRacesWon();
        }

        public int GetRacesWon()
        {
            return matchData.GetRacesWon();
        }

        public void UpdateBestTime( float currentFinalTime )
        {
            matchData.UpdateBestTime( currentFinalTime );
        }

        public float GetBestTime()
        {
            return matchData.GetBestTime();
        }
    }
}
