using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class SettingsMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private Transform desiredCarPosition;
        [SerializeField] private Text bestTimeText;
        [SerializeField] private Text racesWonText;
        [SerializeField] private Text numberOfRacesText;

        private MainMenuMediator mediator;
        private Animations.SettingsMenuAnimations settingsMenuAnimations;
        private Transform carTransform;

        public void Configure( MainMenuMediator menuMediator, Transform _car )
        {
            mediator = menuMediator;
            carTransform = _car;

            settingsMenuAnimations = new Animations.SettingsMenuAnimations( carTransform, desiredCarPosition );
        }

        private void Awake()
        {
            settingsMenu = this.gameObject;
        }

        public void Show( Matchs.InterfaceAdapters.Controller.MatchController matchController )
        {
            settingsMenu.SetActive( true );

            var bestTime = matchController.GetBestTime();
            var racesWon = matchController.GetRacesWon();
            var numberOfRaces = matchController.GetNumberOfRaces();

            bestTimeText.text = $"Best Time: {bestTime.ToString( "F" )}";
            racesWonText.text = $"Races Won: {racesWon.ToString( "F0" )}";
            numberOfRacesText.text = $"Number of Races: {numberOfRaces.ToString( "F0" )}";

            if( carTransform == desiredCarPosition )
            {
                return;
            }

            settingsMenuAnimations.AnimateCarPosition();
        }

        public void Hide()
        {
            settingsMenu.SetActive( false );
        }
    }
}