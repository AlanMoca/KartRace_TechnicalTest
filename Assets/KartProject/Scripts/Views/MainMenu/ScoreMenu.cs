using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class ScoreMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject scoreMenu;
        [SerializeField] private Text bestTimeText;
        [SerializeField] private Text racesWonText;
        [SerializeField] private Text numberOfRacesText;
        [SerializeField] private Button returnButton;

        private MainMenuMediator mediator;

        public void Configure( MainMenuMediator menuMediator )
        {
            mediator = menuMediator;
        }

        private void Awake()
        {
            returnButton.onClick.AddListener( () => mediator.MainMenu() );
        }

        public void Show( Matchs.InterfaceAdapters.Controller.MatchController matchController )
        {
            scoreMenu.SetActive( true );

            var bestTime = matchController.GetBestTime();
            var racesWon = matchController.GetRacesWon();
            var numberOfRaces = matchController.GetNumberOfRaces();

            bestTimeText.text = $"Best Time: {bestTime.ToString( "F" )}";
            racesWonText.text = $"Races Won: {racesWon.ToString( "F0" )}";
            numberOfRacesText.text = $"Number of Races: {numberOfRaces.ToString( "F0" )}";
        }

        public void Hide()
        {
            scoreMenu.SetActive( false );
        }
    }
}


