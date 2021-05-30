using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class LobbyMenu : MonoBehaviour
    {
        [Header( "Class Instance" )]
        [SerializeField] private Event.LobbyPlayButton lobbyPlayButton;

        private MainMenuMediator mediator;
        private TransitionBetweenScenes transitionBetweenScenes;
        private Animations.LobbyMenuAnimations lobbyMenuAnimations;

        [Header( "UI Elements" )]
        [SerializeField] private GameObject lobbyMenu;
        [SerializeField] private Image logoImage;
        [SerializeField] private Button playButton;
        [SerializeField] private Transform desiredCarPosition;
        [SerializeField] private Transform desiredCarPositionWhenPlayButton;

        private Transform carTransform;

        public void Configure( MainMenuMediator menuMediator, Transform _car, TransitionBetweenScenes _transitionBetweenScenes )
        {
            mediator = menuMediator;
            carTransform = _car;
            transitionBetweenScenes = _transitionBetweenScenes;

            playButton.onClick.AddListener( () => Play() );
            lobbyMenuAnimations = new Animations.LobbyMenuAnimations( carTransform, desiredCarPosition, desiredCarPositionWhenPlayButton, logoImage, playButton );
            lobbyPlayButton.Configure( lobbyMenuAnimations );
        }

        public void Show()
        {
            lobbyMenu.SetActive( true );

            if( carTransform == desiredCarPosition )
            {
                return;
            }

            lobbyMenuAnimations.CarPositionAnimation();
            lobbyMenuAnimations.LogoBeatAnimation();
        }

        public void Hide()
        {
            lobbyMenu.SetActive( false );
        }

        private void Play()
        {
            var cloudService = Application.ServiceLocator.Instance.GetService<CloudService.Domain.Entity.ICloudService>();
            if( !cloudService.IsLoggedIn() )
            {
                mediator.AccountMenu();
                playButton.interactable = true;
                var messageService = Application.ServiceLocator.Instance.GetService<Views.Domain.Entity.IMessage>();
                messageService.MessageToShow( $"You are not yet logged. Please login to start playing." );
                return;
            }

            lobbyMenuAnimations.AnimateCarPositionWhenPlayButton();
            transitionBetweenScenes.LoadScene( "Game" );
        }
    }
}