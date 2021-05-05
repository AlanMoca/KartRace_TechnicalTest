using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartRace.Application;

namespace KartRace.Matchs//.ApplicationBusinessLogic or InterfaceAdapters. Es un caso de uso, no?
{
    public class MatchDataSaverPlayerPrefs : IMatchDataSaver
    {
        public void SaveMatchData( MatchData playerData )
        {
            var dataSaver = KartRace.Players.ServiceLocator.Instance.GetService<IDataSaverPlayerPref>();

            dataSaver.SetInt( "NumberOfRaces", playerData.numberOfRaces );
            dataSaver.SetInt( "RacesWon", playerData.racesWon );
            dataSaver.SetFloat( "BestTime", playerData.bestTime );
        }

        public MatchData LoadMatchData()
        {
            var dataSrver = KartRace.Players.ServiceLocator.Instance.GetService<IDataSaverPlayerPref>();

            var _numberOfRaces = dataSrver.GetInt( "NumberOfRaces" );
            var _racesWon = dataSrver.GetInt( "RacesWon" );
            var _bestTime = dataSrver.GetFloat( "BestTime" );

            MatchData matchData = new MatchData() {
                numberOfRaces = _numberOfRaces,
                racesWon = _racesWon,
                bestTime = _bestTime
            };

            return matchData;
        }

        public void SaveBestTime( float newBestTime )
        {
            var dataSaver = KartRace.Players.ServiceLocator.Instance.GetService<IDataSaverPlayerPref>();
            dataSaver.SetFloat( "BestTime", newBestTime );
        }

    }
}
    
