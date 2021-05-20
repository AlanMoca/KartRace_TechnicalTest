using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Animations
{
    public class LobbyMenuAnimations
    {
        private Transform carTransform;
        private Transform desiredCarPosition;
        private Transform desiredCarPositionWhenPlayButton;
        
        private Image logoImage;
        private Button playButton;
        private Transform playButtonTransform;
        private Image playButtonImage;
        private Color originImageColorOfPlayButton;

        public LobbyMenuAnimations( Transform _car, Transform _desiredPosition, Transform _desiredPositionWhenPlay, Image _logoImage, Button _playButton )
        {
            carTransform = _car;
            desiredCarPosition = _desiredPosition;
            desiredCarPositionWhenPlayButton = _desiredPositionWhenPlay;

            logoImage = _logoImage;
            playButton = _playButton;
            playButtonTransform = playButton.GetComponent<Transform>();
            playButtonImage = playButton.GetComponent<Image>();
            originImageColorOfPlayButton = playButtonImage.color;
        }

        public void AnimateCarPositionWhenPlayButton()
        {
            carTransform.DOKill();

            var carSequence = DOTween.Sequence();

            carSequence.
                Append( carTransform.DOMove( desiredCarPositionWhenPlayButton.position, 0.75f, false ) ).
                Join( carTransform.DORotateQuaternion( desiredCarPositionWhenPlayButton.rotation, 0.75f ) );
        }

        public void CarPositionAnimation()
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
            playButtonTransform.DOScale( 1.25f, .25f );
            playButtonImage.DOColor( Color.yellow, 0.25f );
            playButtonTransform.GetChild( 0 ).GetComponent<Text>().DOColor( Color.black, 0.25f );
        }

        public void OnPointerExitPlayButtonAnimation()
        {
            playButtonTransform.DOScale( 1f, .25f );
            playButtonImage.DOColor( originImageColorOfPlayButton, 0.25f );
            playButtonTransform.GetChild( 0 ).GetComponent<Text>().DOColor( Color.white, 0.25f );
        }

        public void LogoBeatAnimation()
        {
            logoImage.transform.DOBlendableMoveBy( new Vector3( 0, 0, 2 ), 7f ).SetEase( Ease.OutElastic ).SetLoops( -1, LoopType.Yoyo );
        }
        

    }
}