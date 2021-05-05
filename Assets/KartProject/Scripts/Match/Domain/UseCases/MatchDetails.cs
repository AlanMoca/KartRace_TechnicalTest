using UnityEngine;

//REVISAR! Es realmente necesario?
//Creo que debería cambiar el nombre de la clase porque realmente sólo se encarga de manejar los datos... La clase Match por sí sola podría hacerlo sólo sería que al crearse
//invocara los métodos de GetService... No necesitaría esta...
namespace KartRace.Matchs.Domain.UseCase
{
    public class MatchDetails : MonoBehaviour
    {
        private Data.IMatchDataSaver matchDataSaver;
        private Entity.MatchData matchData;

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
            matchDataSaver = Application.ServiceLocator.Instance.GetService<KartRace.Matchs.Domain.Data.IMatchDataSaver>();
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