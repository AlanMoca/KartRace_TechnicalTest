using UnityEngine;

namespace KartRace.Views.MainMenu
{
    public class MainMenuMediator : MonoBehaviour
    {
        [SerializeField] private ScoreMenu scoreMenu;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private Matchs.InterfaceAdapters.Controller.MatchController matchController;

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
            scoreMenu.Show( matchController );
            mainMenu.SetActive( false );
        }

        public void MainMenu()
        {
            scoreMenu.Hide();
            mainMenu.SetActive( true );
        }
    }
}
    
