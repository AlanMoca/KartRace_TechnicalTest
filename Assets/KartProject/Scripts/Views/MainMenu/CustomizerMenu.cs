using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class CustomizerMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject customizerMenu;
        [SerializeField] private Transform desiredCarPosition;

        private MainMenuMediator mediator;
        private Animations.CustomizerMenuAnimations customizerMenuAnimations;

        private Transform carTransform;

        public void Configure( MainMenuMediator menuMediator, Transform _car )
        {
            mediator = menuMediator;
            carTransform = _car;

            customizerMenuAnimations = new Animations.CustomizerMenuAnimations( carTransform, desiredCarPosition );
        }

        private void Awake()
        {
            customizerMenu = this.gameObject;
        }

        public void Show()
        {
            customizerMenu.SetActive( true );

            if( carTransform == desiredCarPosition )
            {
                return;
            }

            customizerMenuAnimations.AnimateCarPosition();
        }

        public void Hide()
        {
            customizerMenu.SetActive( false );
        }
    }
}