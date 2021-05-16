using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace KartRace.Animations
{
    public class LobbyMenuAnimations
    {
        private Transform carTransform;
        private Transform desiredCarPosition;
        private Image logoImage;

        private Transform playButton;
        private Image playButtonImage;
        private Color originImageColorOfPlayButton;

        public LobbyMenuAnimations( Transform _car, Transform _desiredPosition, Image _logoImage, Transform _playButton )
        {
            carTransform = _car;
            desiredCarPosition = _desiredPosition;
            logoImage = _logoImage;
            playButton = _playButton;
            playButtonImage = playButton.GetComponent<Image>();
            originImageColorOfPlayButton = playButtonImage.color;
        }

        public void AnimateCarPosition()
        {
            carTransform.DOKill();

            var carSequence = DOTween.Sequence();

            carSequence.
                Append( carTransform.DOMove( desiredCarPosition.position, 0.75f, false ) ).
                Join( carTransform.DORotateQuaternion( desiredCarPosition.rotation, 0.75f ) ).
                OnComplete( () => carSequence.Kill() );

            //carTransform.DOJump( carTransform.position, 1f, 1, 0.05f, false ).SetDelay( 3f ).SetLoops(-1);   //Check documentation
        }

        public void OnPointerEnterPlayButtonAnimation()
        {
            playButton.DOScale( 1.25f, .25f );
            playButtonImage.DOColor( Color.yellow, 0.25f );
            playButton.GetChild( 0 ).GetComponent<Text>().DOColor( Color.black, 0.25f );
        }

        public void OnPointerExitPlayButtonAnimation()
        {
            playButton.DOScale( 1f, .25f );
            playButtonImage.DOColor( originImageColorOfPlayButton, 0.25f );
            playButton.GetChild( 0 ).GetComponent<Text>().DOColor( Color.white, 0.25f );
        }

    }
}