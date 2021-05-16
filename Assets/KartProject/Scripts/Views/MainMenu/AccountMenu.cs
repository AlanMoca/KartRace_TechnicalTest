using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class AccountMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject accountMenu;
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
            accountMenu = this.gameObject;
        }

        public void Show()
        {
            accountMenu.SetActive( true );
        }

        public void Hide()
        {
            accountMenu.SetActive( false );
        }
    }
}