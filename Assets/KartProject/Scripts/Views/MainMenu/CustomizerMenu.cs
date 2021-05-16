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
        private Transform currentCarPosition;

        public void Configure( MainMenuMediator menuMediator, Transform carPosition )
        {
            mediator = menuMediator;
            currentCarPosition = carPosition;
        }

        private void Awake()
        {
            customizerMenu = this.gameObject;
        }

        public void Show()
        {
            customizerMenu.SetActive( true );


            if( currentCarPosition == myDesiredCarPosition )
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
            var carSequence = DOTween.Sequence();

            carSequence.
                Append( currentCarPosition.DOMove( myDesiredCarPosition.position, 0.75f, false ) ).
                Join( currentCarPosition.DORotateQuaternion( myDesiredCarPosition.rotation, 0.75f ) );
        }        
    }
}