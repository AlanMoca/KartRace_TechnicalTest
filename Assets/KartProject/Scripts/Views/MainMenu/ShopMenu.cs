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
        private Transform carTransform;

        public void Configure( MainMenuMediator menuMediator, Transform _car )
        {
            mediator = menuMediator;
            carTransform = _car;
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