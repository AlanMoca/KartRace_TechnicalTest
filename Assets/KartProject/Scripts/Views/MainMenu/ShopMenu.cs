using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class ShopMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject shopMenu;
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
            shopMenu = this.gameObject;
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