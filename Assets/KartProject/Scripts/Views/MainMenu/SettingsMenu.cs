using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class SettingsMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject settingsMenu;
        [SerializeField] private Transform myDesiredCarPosition;

        private MainMenuMediator mediator;
        private Transform currentCarPosition;

        public void Configure( MainMenuMediator menuMediator, Transform carPosition )
        {
            mediator = menuMediator;
            currentCarPosition = carPosition;
        }

        private void Awake()
        {
            settingsMenu = this.gameObject;
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