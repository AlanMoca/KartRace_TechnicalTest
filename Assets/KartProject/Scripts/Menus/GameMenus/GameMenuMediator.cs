using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuMediator : MonoBehaviour
{
    [SerializeField] private StartGameUI startGameUI;
    [SerializeField] private InGameUI inGameUI;
    [SerializeField] private EndGameUI endGameMenu;

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
    }

    public void MainMenu()
    {
    }
}
