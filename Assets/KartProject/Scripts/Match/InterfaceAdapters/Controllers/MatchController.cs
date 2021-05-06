using UnityEngine;
using KartRace.Matchs.Domain.Data;
using KartRace.Matchs.Domain.Entity;

namespace KartRace.Matchs.InterfaceAdapters.Controller
{
    public class MatchController : MonoBehaviour
    {
        private IMatchDataSaver matchDataSaver;
        private MatchData matchData;

        public void Configure( IMatchDataSaver _matchDataSaver, MatchData _matchData )
        {
            matchDataSaver = _matchDataSaver;
            matchData = _matchData;
        }

        public void SaveMatchData()
        {
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