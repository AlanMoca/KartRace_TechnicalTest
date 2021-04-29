using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    [Header( "Start Class Instances" )]
    [SerializeField] private SimpleTimerUpdate startGameTimer;

    [Header( "InGame Class Instances" )]
    [SerializeField] private SimpleTimerUpdate inGameTimer;

    [Header( "General Class Instances" )]
    [SerializeField] private KartRace.Cars.CarController carController;
    [SerializeField] private GameMenuMediator gameMenuMediator;

    public void StartGame()
    {
        carController.enabled = false;
        gameMenuMediator.StartGame();

        startGameTimer.StarTimer();
    }

    public void InGame()
    {
        carController.enabled = true;
        startGameTimer.StopTimer();
        gameMenuMediator.InGame();

        inGameTimer.StarTimer();
    }

    public void EndGame(bool playerWon)
    {
        carController.enabled = false;
        inGameTimer.StopTimer();
        var currentTime = inGameTimer.GetCurrentTime();

        gameMenuMediator.EndGame( playerWon, currentTime );
    }

}
