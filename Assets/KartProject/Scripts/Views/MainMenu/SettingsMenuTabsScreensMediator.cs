using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class SettingsMenuTabsScreensMediator : MonoBehaviour
    {
        [Header( "Class Instances" )]
        [SerializeField] private ControlsTabScreen controlsTabScreen;
        [SerializeField] private SoundTabScreen soundTabScreen;
        [SerializeField] private LeaderboardTabScreen leaderboardTabScreen;
        [SerializeField] private StadisticsTabScreen stadisticsTabScreen;

        private MainMenuMediator mediator;
        private Animations.SettingsMenuAnimations settingsMenuAnimations;

        [Header( "UI Elements" )]
        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private Transform desiredCarPosition;

        [Space()]
        [SerializeField] private Button controlsTabButton;
        [SerializeField] private Button soundTabButton;
        [SerializeField] private Button leaderboardTabButton;
        [SerializeField] private Button stadisticsTabButton;
        
        private Transform carTransform;

        public void Configure( MainMenuMediator menuMediator, Transform _car, Matchs.InterfaceAdapters.Controller.MatchController _matchController )
        {
            mediator = menuMediator;
            carTransform = _car;

            settingsMenuAnimations = new Animations.SettingsMenuAnimations( carTransform, desiredCarPosition );

            controlsTabButton.onClick.AddListener( () => ControlsTabScreen( _matchController ) );
            soundTabButton.onClick.AddListener( () => SoundTabScreen( _matchController ) );
            leaderboardTabButton.onClick.AddListener( () => LeaderboardTabScreen( _matchController ) );
            stadisticsTabButton.onClick.AddListener( () => StadisticsTabScreen( _matchController ) );

            controlsTabScreen.Configure( this );
            soundTabScreen.Configure( this );
            leaderboardTabScreen.Configure( this );
            stadisticsTabScreen.Configure( this );
        }

        public void Show()
        {
            settingsMenu.SetActive( true );
            stadisticsTabButton.onClick.Invoke();

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

        public void ControlsTabScreen( Matchs.InterfaceAdapters.Controller.MatchController _matchController )
        {
            controlsTabScreen.Show( _matchController );
            soundTabScreen.Hide();
            leaderboardTabScreen.Hide();
            stadisticsTabScreen.Hide();
        }

        public void SoundTabScreen( Matchs.InterfaceAdapters.Controller.MatchController _matchController )
        {
            controlsTabScreen.Hide();
            soundTabScreen.Show( _matchController );
            leaderboardTabScreen.Hide();
            stadisticsTabScreen.Hide();
        }

        public void LeaderboardTabScreen( Matchs.InterfaceAdapters.Controller.MatchController _matchController )
        {
            controlsTabScreen.Hide();
            soundTabScreen.Hide();
            leaderboardTabScreen.Show( _matchController );
            stadisticsTabScreen.Hide();
        }

        public void StadisticsTabScreen( Matchs.InterfaceAdapters.Controller.MatchController _matchController )
        {
            controlsTabScreen.Hide();
            soundTabScreen.Hide();
            leaderboardTabScreen.Hide();
            stadisticsTabScreen.Show( _matchController );
        }
    }
}