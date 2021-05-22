using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class ControlsTabScreen : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject controlsTabScreen;

        private SettingsMenuTabsScreensMediator tabsMediator;

        public void Configure( SettingsMenuTabsScreensMediator _tabsMediator )
        {
            tabsMediator = _tabsMediator;
        }

        public void Show( Matchs.InterfaceAdapters.Controller.MatchController matchController )
        {
            controlsTabScreen.SetActive( true );
        }

        public void Hide()
        {
            controlsTabScreen.SetActive( false );
        }
    }
}