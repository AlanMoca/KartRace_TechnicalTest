using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class CustomizerMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject customizerMenu;

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
            customizerMenu.SetActive( true );
        }

        public void Hide()
        {
            customizerMenu.SetActive( false );
        }
    }
}