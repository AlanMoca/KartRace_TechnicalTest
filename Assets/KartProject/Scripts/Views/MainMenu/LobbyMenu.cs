using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class LobbyMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private Transform myDesiredCarPosition;

        //Instance of Class
        private MainMenuMediator mediator;
        private Animations.LobbyMenuAnimations lobbyMenuAnimations;

        //Unity Instance Elements
        private GameObject lobbyMenu;
        private Transform carTransform;
        

        public void Configure( MainMenuMediator menuMediator, Transform _car )
        {
            mediator = menuMediator;
            carTransform = _car;

            lobbyMenuAnimations = new Animations.LobbyMenuAnimations( carTransform, myDesiredCarPosition );
        }

        private void Awake()
        {
            lobbyMenu = this.gameObject;
        }

        public void Show()
        {
            lobbyMenu.SetActive( true );


            if( carTransform == myDesiredCarPosition )
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