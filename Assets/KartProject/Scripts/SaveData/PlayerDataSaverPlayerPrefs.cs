using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartRace.Application;

namespace KartRace.Players//.ApplicationBusinessLogic or InterfaceAdapters. Es un caso de uso, no?
{
    public class PlayerDataSaverPlayerPrefs : IPlayerDataSaver
    {
        public void SavePlayerData( PlayerData playerData )
        {
            var dataSaver = ServiceLocator.Instance.GetService<IDataSaverPlayerPref>();

            dataSaver.SetInt( "NumberOfRaces", playerData.numberOfRaces );
            dataSaver.SetInt( "RacesWon", playerData.racesWon );
            dataSaver.SetFloat( "BestTime", playerData.bestTime );
        }

        public PlayerData LoadPlayerData()
        {
            var dataSrver = ServiceLocator.Instance.GetService<IDataSaverPlayerPref>();

            var _numberOfRaces = dataSrver.GetInt( "NumberOfRaces" );
            var _racesWon = dataSrver.GetInt( "RacesWon" );
            var _bestTime = dataSrver.GetFloat( "BestTime" );

            PlayerData playerData = new PlayerData() {
                numberOfRaces = _numberOfRaces,
                racesWon = _racesWon,
                bestTime = _bestTime
            };

            return playerData;
        }

    }
}



//namespace KartRace.Players//.InterfaceAdapters or Framworks&Drivers?
//{
//    public class PlayerDataSaverPlayerPrefs : IPlayerDataSaver
//    {
//        private PlayerPrefAdapter playerPrefAdapter;

//        public PlayerDataSaverPlayerPrefs()
//        {
//            playerPrefAdapter = new PlayerPrefAdapter();
//        }

//        public void SavePlayerData( PlayerData playerData )
//        {
//            playerPrefAdapter.SetInt( "NumberOfRaces", playerData.numberOfRaces );
//            playerPrefAdapter.SetInt( "RacesWon", playerData.racesWon );
//            playerPrefAdapter.SetFloat( "BestTime", playerData.bestTime );
//        }

//        public PlayerData LoadPlayerData()
//        {
//            var _numberOfRaces = playerPrefAdapter.GetInt( "NumberOfRaces" );
//            var _racesWon = playerPrefAdapter.GetInt( "RacesWon" );
//            var _bestTime = playerPrefAdapter.GetFloat( "BestTime" );

//            PlayerData playerData = new PlayerData() {
//                numberOfRaces = _numberOfRaces,
//                racesWon = _racesWon,
//                bestTime = _bestTime
//            };

//            return playerData;
//        }
//    }
//}