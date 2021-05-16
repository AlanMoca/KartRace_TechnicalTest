using UnityEngine;
using DG.Tweening;

namespace KartRace.Animations
{
    public class CustomizerMenuAnimations
    {
        private Transform carTransform;
        private Transform desiredCarPosition;

        public CustomizerMenuAnimations( Transform _car, Transform _desiredPosition )
        {
            carTransform = _car;
            desiredCarPosition = _desiredPosition;
        }

        public void AnimateCarPosition()
        {
            carTransform.DOKill();

            var carSequence = DOTween.Sequence();

            carSequence.
                Append( carTransform.DOMove( desiredCarPosition.position, 0.75f, false ) ).
                Join( carTransform.DORotateQuaternion( desiredCarPosition.rotation, 0.75f ) );
        }
    }
}