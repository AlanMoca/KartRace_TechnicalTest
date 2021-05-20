using UnityEngine;
using DG.Tweening;

namespace KartRace.Animations
{
    public class AccountMenuAnimations
    {
        private Transform carTransform;
        private Transform desiredCarPosition;

        public AccountMenuAnimations( Transform _car, Transform _desiredPosition )
        {
            carTransform = _car;
            desiredCarPosition = _desiredPosition;
        }

        public void AnimateCarPosition()
        {
            carTransform.DOKill();

            var carSequence = DOTween.Sequence();

            carSequence.
                Append( carTransform.DOMove( desiredCarPosition.position, 1f, false ) ).
                Join( carTransform.DORotateQuaternion( desiredCarPosition.rotation, 0.75f ) );
        }
    }
}