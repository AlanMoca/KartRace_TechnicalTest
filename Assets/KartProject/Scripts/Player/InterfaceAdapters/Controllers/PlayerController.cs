using UnityEngine;

//REVISAR! Es realmente necesario?
//Creo que debería cambiar el nombre de la clase porque realmente sólo se encarga de manejar los datos... La clase Match por sí sola podría hacerlo sólo sería que al crearse
//invocara los métodos de GetService... No necesitaría esta...
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
