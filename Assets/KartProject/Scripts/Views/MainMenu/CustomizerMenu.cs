using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class CustomizerMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject customizerMenu;
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
            customizerMenu = this.gameObject;
        }

        public void Show()
        {
            customizerMenu.SetActive( true );


            if( carTransform == myDesiredCarPosition )
            {
                return;
            }

            AnimateCarPosition();
        }

        public void Hide()
        {
            customizerMenu.SetActive( false );
        }

        private void AnimateCarPosition()
        {
            carTransform.DOKill();

            var carSequence = DOTween.Sequence();

            carSequence.
                Append( carTransform.DOMove( myDesiredCarPosition.position, 0.75f, false ) ).
                Join( carTransform.DORotateQuaternion( myDesiredCarPosition.rotation, 0.75f ) );
        }        
    }
}