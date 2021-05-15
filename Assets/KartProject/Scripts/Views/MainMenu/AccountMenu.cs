using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class AccountMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject accountMenu;

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
            accountMenu.SetActive( true );
        }

        public void Hide()
        {
            accountMenu.SetActive( false );
        }
    }
}