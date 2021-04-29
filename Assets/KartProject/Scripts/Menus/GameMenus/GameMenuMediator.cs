using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> bfb516fd430968f96b030121b66a307e7afd521f

public class GameMenuMediator : MonoBehaviour
{
    [SerializeField] private StartGameUI startGameUI;
    [SerializeField] private InGameUI inGameUI;
    [SerializeField] private EndGameUI endGameMenu;
<<<<<<< HEAD
    [SerializeField] private TransitionBetweenScenes transitionBetweenScenes;
=======
>>>>>>> bfb516fd430968f96b030121b66a307e7afd521f

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

    public void EndGame( bool playerWon, float currentTime )
    {
        inGameUI.Hide();
        endGameMenu.Show( playerWon, currentTime );
    }

    public void TryAgain()
    {
<<<<<<< HEAD
        transitionBetweenScenes.LoadScene( "Game" );
=======
        //Recargar scena
>>>>>>> bfb516fd430968f96b030121b66a307e7afd521f
    }

    public void MainMenu()
    {
<<<<<<< HEAD
        transitionBetweenScenes.LoadScene( "Menu" );
=======
        //CargarScena anterior
>>>>>>> bfb516fd430968f96b030121b66a307e7afd521f
    }
}
