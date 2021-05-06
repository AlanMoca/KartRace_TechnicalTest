using UnityEngine;
using KartRace.Timers.Domain.UseCase;

namespace KartRace.Application
{
    public class GameFacade : MonoBehaviour
    {
        [Header( "Start Class Instances" )]
        [SerializeField] private SimpleTimerUpdate startGameTimer;

        [Header( "InGame Class Instances" )]
        [SerializeField] private SimpleTimerUpdate inGameTimer;
        [Header( "InGame Class Instances" )]
        [SerializeField] private KartRace.Matchs.InterfaceAdapters.Controller.MatchController matchController;

        [Header( "General Class Instances" )]
        //Esto yo creo es un error mío en el diseño de la arquitectura. No se si al ver donde poner el facade o con el interfaceAdapters de CarController... (Creo yo es CarController porque no debería llamarse así,
        //ya que maneja mucha lógica importante que hay que desacoplar, crear la entidad, etc).
        [SerializeField] private Cars.InterfaceAdapters.Controller.CarController carController;
        [SerializeField] private KartRace.Views.GameMenu.GameMenuMediator gameMenuMediator;

        public void StartGame()
        {
            carController.enabled = false;
            gameMenuMediator.StartGame();
            matchController.AddNumberOfRaces();
            startGameTimer.StarTimer();
        }

        public void InGame()
        {
            carController.enabled = true;
            startGameTimer.StopTimer();
            gameMenuMediator.InGame();

            inGameTimer.StarTimer();
        }

        public void EndGame( bool playerWon )
        {
            carController.enabled = false;

            inGameTimer.StopTimer();
            var currentFinalTime = inGameTimer.GetCurrentTime();
            var lastBestTime = matchController.GetBestTime();

            if( playerWon )
            {
                matchController.AddRacesWon();
                matchController.UpdateBestTime( currentFinalTime );
            }

            gameMenuMediator.EndGame( playerWon, lastBestTime, currentFinalTime );

            matchController.SaveMatchData();

        }

    }
}

