using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class SettingsMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject settingsMenu;

        private MainMenuMediator mediator;

        public void Configure( MainMenuMediator menuMediator )
        {
            mediator = menuMediator;
        }

        private void Awake()
        {

        }

        public void Show()
        {
            settingsMenu.SetActive( true );
        }

        public void Hide()
        {
            settingsMenu.SetActive( false );
        }
    }
}