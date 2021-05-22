using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class StadisticsTabScreen : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject stadisticsTabScreen;
        [SerializeField] private Text bestTimeText;
        [SerializeField] private Text racesWonText;
        [SerializeField] private Text numberOfRacesText;

        private SettingsMenuTabsScreensMediator tabsMediator;

        public void Configure( SettingsMenuTabsScreensMediator _tabsMediator )
        {
            tabsMediator = _tabsMediator;
            //buttonOfThisScreen.onClick.AddListener( () => MethodOfThatButton() );
        }

        public void Show( Matchs.InterfaceAdapters.Controller.MatchController matchController )
        {
            stadisticsTabScreen.SetActive( true );

            var bestTime = matchController.GetBestTime();
            var racesWon = matchController.GetRacesWon();
            var numberOfRaces = matchController.GetNumberOfRaces();

            bestTimeText.text = $"{bestTime.ToString( "F" )}";
            racesWonText.text = $"{racesWon.ToString( "F0" )}";
            numberOfRacesText.text = $"{numberOfRaces.ToString( "F0" )}";
        }

        public void Hide()
        {
            stadisticsTabScreen.SetActive( false );
        }
    }
}