using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    [Header( "Start Class Instances" )]
    [SerializeField] private SimpleTimerUpdate startGameTimer;

    [Header( "InGame Class Instances" )]
    [SerializeField] private SimpleTimerUpdate inGameTimer;
    [Header( "InGame Class Instances" )]
    [SerializeField] private KartRace.Matchs.MatchDetails matchDetails;

    [Header( "General Class Instances" )]
    [SerializeField] private KartRace.Cars.CarController carController;
    [SerializeField] private GameMenuMediator gameMenuMediator;

    public void StartGame()
    {
        carController.enabled = false;
        gameMenuMediator.StartGame();
        matchDetails.AddNumberOfRaces();
        startGameTimer.StarTimer();
    }

    public void InGame()
    {
        carController.enabled = true;
        startGameTimer.StopTimer();
        gameMenuMediator.InGame();

        inGameTimer.StarTimer();
    }

    //public void EndGame(bool playerWon)
    //{
    //    carController.enabled = false;
    //    inGameTimer.StopTimer();
    //    var currentFinalTime = inGameTimer.GetCurrentTime();

    //    gameMenuMediator.EndGame( playerWon, currentFinalTime );
    //}

    public void EndGame( bool playerWon )
    {
        carController.enabled = false;

        inGameTimer.StopTimer();
        var currentFinalTime = inGameTimer.GetCurrentTime();
        var lastBestTime = matchDetails.GetBestTime();

        if( playerWon )
        {
            matchDetails.AddRacesWon();
            matchDetails.UpdateBestTime( currentFinalTime );
        }

        gameMenuMediator.EndGame( playerWon, lastBestTime, currentFinalTime );

        //SalvarDatos pero por lo que entiendo ya todo se actualizo en matchData por lo que al hacer disable se guarda automáticamente

    }

}
