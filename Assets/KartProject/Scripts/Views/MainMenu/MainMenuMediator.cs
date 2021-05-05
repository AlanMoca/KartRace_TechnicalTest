using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartRace.Views.MainMenu
{
    public class MainMenuMediator : MonoBehaviour
    {
        [SerializeField] private ScoreMenu scoreMenu;
        [SerializeField] private GameObject mainMenu;

        private void Awake()
        {
            scoreMenu.Configure( this );
        }

        private void Start()
        {
            scoreMenu.Hide();
        }

        public void ScoreMenu()
        {
            scoreMenu.Show();
            mainMenu.SetActive( false );
        }

        public void MainMenu()
        {
            scoreMenu.Hide();
            mainMenu.SetActive( true );
        }
    }
}
    
