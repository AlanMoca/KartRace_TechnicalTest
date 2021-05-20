using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Animations
{
    public class MainMenuAnimations
    {
        private Image transitionBetweenMenusImage;

        public MainMenuAnimations( Image _transitionBetweenMenusImage )
        {
            transitionBetweenMenusImage = _transitionBetweenMenusImage;
        }

        public void AnimateTransitionBetweenMenus()
        {
            var transparentColor = transitionBetweenMenusImage.color;
            var opaqueColor = transitionBetweenMenusImage.color;
            opaqueColor.a = 1;

            var backgoundSequence = DOTween.Sequence();

            backgoundSequence.
                Append( transitionBetweenMenusImage.DOColor( opaqueColor, 0.05f ) ).
                Append( transitionBetweenMenusImage.DOColor( transparentColor, 0.05f ) );
        }
    }
}