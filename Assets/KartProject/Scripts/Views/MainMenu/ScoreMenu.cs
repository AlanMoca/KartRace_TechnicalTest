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

        private int numberOfRaces;
        private int racesWon;
        private float bestTime;

        public void Configure( MainMenuMediator menuMediator )
        {
            mediator = menuMediator;
        }

        private void Awake()
        {
            returnButton.onClick.AddListener( () => mediator.MainMenu() );
        }

        private void OnEnable()
        {
            //Intentar con un MatchData sin usar un MatchDetail
            var dataSaver = KartRace.Application.ServiceLocator.Instance.GetService<KartRace.Matchs.Domain.Data.IMatchDataSaver>();

            var matchData = dataSaver.LoadMatchData();

            numberOfRaces = matchData.numberOfRaces;
            racesWon = matchData.racesWon;
            bestTime = matchData.bestTime;
        }

        public void Show()
        {
            scoreMenu.SetActive( true );
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


