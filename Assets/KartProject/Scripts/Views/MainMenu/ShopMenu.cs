using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class ShopMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject shopMenu;

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
            shopMenu.SetActive( true );
        }

        public void Hide()
        {
            shopMenu.SetActive( false );
        }
    }
}