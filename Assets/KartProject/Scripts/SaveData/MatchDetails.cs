using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartRace.Matchs//.Entity
{
    public class MatchDetails : MonoBehaviour
    {
        private IMatchDataSaver matchDataSaver;
        private MatchData matchData;

        private void OnEnable()
        {
            GetMatchData();
        }

        private void OnDisable()
        {
            matchDataSaver.SaveMatchData( matchData );
        }

        private void GetMatchData()
        {
            matchDataSaver = KartRace.Players.ServiceLocator.Instance.GetService<IMatchDataSaver>();
            matchData = matchDataSaver.LoadMatchData();
        }

        private void SaveMatchData()
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

        public void UpdateBestTime(float currentFinalTime)
        {
            matchData.UpdateBestTime( currentFinalTime );
        }

        public float GetBestTime()
        {
            return matchData.GetBestTime();
        }
    }
}


//////////////////////////////////////////////////////////////////////////////////////
///

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace KartRace.Matchs//.Entity
//{
//    public class MatchDetails : MonoBehaviour
//    {
//        private IMatchDataSaver matchDataSaver;
//        private int numberOfRaces;
//        private int racesWon;
//        private float bestTime;

//        public MatchData MatchData
//        {
//            get; private set;
//        }

//        private void OnEnable()
//        {
//            matchDataSaver = KartRace.Players.ServiceLocator.Instance.GetService<IMatchDataSaver>();

//            MatchData = matchDataSaver.LoadMatchData();
//            numberOfRaces = MatchData.numberOfRaces;
//            racesWon = MatchData.racesWon;
//            bestTime = MatchData.bestTime;
//        }

//        private void Start()
//        {
//            //numberOfRaces++;
//        }

//        private void OnDisable()
//        {
//            //BORRAR?
//            MatchData _matchData = new MatchData {
//                numberOfRaces = this.numberOfRaces,
//                racesWon = this.racesWon,
//                bestTime = this.bestTime
//            };

//            matchDataSaver.SaveMatchData( _matchData );
//            //Si no guarda bien los datos aquí deben guardarse en el start
//        }

//        public void AddNumberOfRaces()
//        {
//            numberOfRaces++;
//            //MatchData.numberOfRaces++;
//        }

//        public int GetNumberOfRaces()
//        {
//            return numberOfRaces;
//        }

//        public void AddRacesWon()
//        {
//            racesWon++;
//        }

//        public int GetRacesWon()
//        {
//            return racesWon;
//        }

//        public void UpdateBestTime( float currentFinalTime )
//        {
//            if( bestTime >= currentFinalTime )
//            {
//                return;
//                //MatchData.bestTime = bestTime;
//            }
//            else
//            {
//                bestTime = currentFinalTime;
//                //MatchData.bestTime = currentFinalTime;
//            }
//        }

//        public float GetBestTime()
//        {
//            return bestTime;
//        }

//        private void Update()
//        {
//            //UpdateCashUI();
//        }

//    }
//}