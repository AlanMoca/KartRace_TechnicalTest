using UnityEngine;

//REVISAR! Es realmente necesario?
//Creo que deber�a cambiar el nombre de la clase porque realmente s�lo se encarga de manejar los datos... La clase Match por s� sola podr�a hacerlo s�lo ser�a que al crearse
//invocara los m�todos de GetService... No necesitar�a esta...
namespace KartRace.Players.InterfaceAdapters.Controller
{
    public class PlayerController : MonoBehaviour
    {
        private Domain.Entity.IPlayerDataSaver matchDataSaver;
        private Domain.Entity.PlayerData matchData;

        private void OnEnable()
        {
            GetMatchData();
        }

        private void OnDisable()
        {
            matchDataSaver.SavePlayerData( matchData );
        }

        private void GetMatchData()
        {
            matchDataSaver = Application.ServiceLocator.Instance.GetService<Domain.Entity.IPlayerDataSaver>();
            matchData = matchDataSaver.LoadPlayerData();
        }

        private void SaveMatchData()
        {
            matchDataSaver.SavePlayerData( matchData );
        }

        //public void AddNumberOfRaces()
        //{
        //    matchData.AddNumberOfRaces();
        //}

        //public int GetNumberOfRaces()
        //{
        //    return matchData.GetNumberOfRaces();
        //}

        //public void AddRacesWon()
        //{
        //    matchData.AddRacesWon();
        //}

        //public int GetRacesWon()
        //{
        //    return matchData.GetRacesWon();
        //}

        //public void UpdateBestTime( float currentFinalTime )
        //{
        //    matchData.UpdateBestTime( currentFinalTime );
        //}

        //public float GetBestTime()
        //{
        //    return matchData.GetBestTime();
        //}
    }
}
