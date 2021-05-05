using UnityEngine;

namespace KartRace.Views.GameMenu
{
    public class GameMenuMediator : MonoBehaviour
    {
        [SerializeField] private StartGameUI startGameUI;
        [SerializeField] private InGameUI inGameUI;
        [SerializeField] private EndGameUI endGameMenu;
        [SerializeField] private TransitionBetweenScenes transitionBetweenScenes;

        private void Awake()
        {
            startGameUI.Configure( this );
            inGameUI.Configure( this );
            endGameMenu.Configure( this );
        }

        private void Start()
        {
            startGameUI.Show();
            inGameUI.Hide();
            endGameMenu.Hide();
        }

        public void StartGame()
        {
            startGameUI.Show();
        }

        public void InGame()
        {
            startGameUI.Hide();
            inGameUI.Show();
        }

        public void EndGame( bool playerWon, float lastBestTime, float currentFinalTime )
        {
            inGameUI.Hide();
            endGameMenu.Show( playerWon, lastBestTime, currentFinalTime );
        }

        public void TryAgain()
        {
            transitionBetweenScenes.LoadScene( "Game" );
        }

        public void MainMenu()
        {
            transitionBetweenScenes.LoadScene( "Menu" );
        }
    }
}
    
