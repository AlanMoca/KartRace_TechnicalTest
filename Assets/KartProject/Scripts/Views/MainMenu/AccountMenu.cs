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
        private Transform currentCarPosition;

        public void Configure( MainMenuMediator menuMediator, Transform carPosition )
        {
            mediator = menuMediator;
            currentCarPosition = carPosition;
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