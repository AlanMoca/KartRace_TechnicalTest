using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class SoundTabScreen : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject soundTabScreen;

        private SettingsMenuTabsScreensMediator tabsMediator;

        public void Configure( SettingsMenuTabsScreensMediator _tabsMediator )
        {
            tabsMediator = _tabsMediator;
        }

        public void Show( Matchs.InterfaceAdapters.Controller.MatchController matchController )
        {
            soundTabScreen.SetActive( true );
        }

        public void Hide()
        {
            soundTabScreen.SetActive( false );
        }
    }
}