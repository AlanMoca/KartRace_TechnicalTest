using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class ShopMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject shopMenu;
        [SerializeField] private Transform desiredCarPosition;

        private MainMenuMediator mediator;
        private Animations.ShopMenuAnimations shopMenuAnimations;
        private Transform carTransform;

        public void Configure( MainMenuMediator menuMediator, Transform _car )
        {
            mediator = menuMediator;
            carTransform = _car;

            shopMenuAnimations = new Animations.ShopMenuAnimations( carTransform, desiredCarPosition );
        }

        private void Awake()
        {
            shopMenu = this.gameObject;
        }

        public void Show()
        {
            shopMenu.SetActive( true );

            if( carTransform == desiredCarPosition )
            {
                return;
            }

            shopMenuAnimations.AnimateCarPosition();
        }

        public void Hide()
        {
            shopMenu.SetActive( false );
        }
    }
}