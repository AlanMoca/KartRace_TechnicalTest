using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class LobbyMenu : MonoBehaviour
    {
        [Header( "Events Class Instance" )]
        [SerializeField] private Events.LobbyPlayButton lobbyPlayButton;

        [Header( "UI Elements" )]
        [SerializeField] private Image logoImage;
        [SerializeField] private Transform playButton;
        [SerializeField] private Transform desiredCarPosition;

        private MainMenuMediator mediator;
        private Animations.LobbyMenuAnimations lobbyMenuAnimations;

        private GameObject lobbyMenu;
        private Transform carTransform;

        public void Configure( MainMenuMediator menuMediator, Transform _car )
        {
            mediator = menuMediator;
            carTransform = _car;

            lobbyMenuAnimations = new Animations.LobbyMenuAnimations( carTransform, desiredCarPosition, logoImage, playButton );
            lobbyPlayButton.Configure( lobbyMenuAnimations );
        }

        private void Awake()
        {
            lobbyMenu = this.gameObject;
        }

        public void Show()
        {
            lobbyMenu.SetActive( true );


            if( carTransform == desiredCarPosition )
            {
                return;
            }

            lobbyMenuAnimations.AnimateCarPosition();
        }

        public void Hide()
        {
            lobbyMenu.SetActive( false );
        }
    }
}