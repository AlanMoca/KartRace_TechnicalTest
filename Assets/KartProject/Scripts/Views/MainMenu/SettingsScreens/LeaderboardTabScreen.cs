using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class LeaderboardTabScreen : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject leaderboardTabScreen;

        private SettingsMenuTabsScreensMediator tabsMediator;

        public void Configure( SettingsMenuTabsScreensMediator _tabsMediator )
        {
            tabsMediator = _tabsMediator;
        }

        public void Show( Matchs.InterfaceAdapters.Controller.MatchController matchController )
        {
            leaderboardTabScreen.SetActive( true );
        }

        public void Hide()
        {
            leaderboardTabScreen.SetActive( false );
        }
    }
}