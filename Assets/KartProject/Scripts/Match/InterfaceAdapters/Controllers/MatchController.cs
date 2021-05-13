using UnityEngine;
using KartRace.Matchs.Domain.Entity;

namespace KartRace.Matchs.InterfaceAdapters.Controller
{
    public class MatchController : MonoBehaviour
    {
        private KartRace.SaveSystems.Domain.Entity.IDataSaver genericDataSaver;
        private IMatchDataSaver matchDataSaver;
        private MatchData matchData;
        private bool useGenericSaveSyste;

        public void Configure( KartRace.SaveSystems.Domain.Entity.IDataSaver _dataSaver, MatchData _matchData )
        {
            genericDataSaver = _dataSaver;
            matchData = _matchData;
            useGenericSaveSyste = true;
        }

        public void Configure( IMatchDataSaver _matchDataSaver, MatchData _matchData )
        {
            matchDataSaver = _matchDataSaver;
            matchData = _matchData;
            useGenericSaveSyste = false;
        }

        public void SaveMatchData()
        {
            if( useGenericSaveSyste )
                genericDataSaver.SaveData<MatchData>( matchData, "matchData" );
            else
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
