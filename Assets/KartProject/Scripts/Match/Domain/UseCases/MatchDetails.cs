using UnityEngine;

//REVISAR! Es realmente necesario?
//Creo que deber�a cambiar el nombre de la clase porque realmente s�lo se encarga de manejar los datos... La clase Match por s� sola podr�a hacerlo s�lo ser�a que al crearse
//invocara los m�todos de GetService... No necesitar�a esta...
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