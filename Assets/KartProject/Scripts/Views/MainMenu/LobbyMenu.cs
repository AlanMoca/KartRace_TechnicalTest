using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class LobbyMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject lobbyMenu;
        //[SerializeField] private Image lobbyBackgroundImage;
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
            lobbyMenu = this.gameObject;
        }

        public void Show()
        {
            lobbyMenu.SetActive( true );


            if( currentCarPosition == myDesiredCarPosition )
            {
                return;
            }

            AnimateCarPosition();
        }

        public void Hide()
        {
            lobbyMenu.SetActive( false );
        }

        private void AnimateCarPosition()
        {
            var carSequence = DOTween.Sequence();

            carSequence.
                Append( currentCarPosition.DOMove( myDesiredCarPosition.position, 0.75f, false ) ).
                Join( currentCarPosition.DORotateQuaternion( myDesiredCarPosition.rotation, 0.75f ) );
        }

        //private void AnimateTransitionBetweenMenus()
        //{
        //    var transparentColor = lobbyBackgroundImage.color;
        //    var opaqueColor = lobbyBackgroundImage.color;
        //    opaqueColor.a = 1;

        //    var backgoundSequence = DOTween.Sequence();

        //    backgoundSequence.
        //        Append( lobbyBackgroundImage.DOColor( opaqueColor, 0.20f ) ).
        //        Append( lobbyBackgroundImage.DOColor( transparentColor, 0.20f ) );
        //}

    }
}