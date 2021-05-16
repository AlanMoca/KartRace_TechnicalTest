using UnityEngine;
using DG.Tweening;

namespace KartRace.Animations
{
    public class LobbyMenuAnimations
    {
        private Transform carTransform;
        private Transform desiredCarPosition;

        public LobbyMenuAnimations( Transform _car, Transform _desiredPosition )
        {
            carTransform = _car;
            desiredCarPosition = _desiredPosition;
        }

        public void AnimateCarPosition()
        {
            carTransform.DOKill();

            var carSequence = DOTween.Sequence();

            carSequence.
                SetLoops( -1 ).
                Append( carTransform.DOMove( desiredCarPosition.position, 0.75f, false ) ).
                Join( carTransform.DORotateQuaternion( desiredCarPosition.rotation, 0.75f ) ).
                Append( carTransform.DOJump( desiredCarPosition.position, 1f, 1, 0.05f, false ).SetDelay( 1f )
                );
        }
    }
}