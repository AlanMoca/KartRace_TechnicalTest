using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class LobbyMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject lobbyMenu;

        private MainMenuMediator mediator;

        public void Configure( MainMenuMediator menuMediator )
        {
            mediator = menuMediator;
        }

        private void Awake()
        {

        }

        public void Show()
        {
            lobbyMenu.SetActive( true );
        }

        public void Hide()
        {
            lobbyMenu.SetActive( false );
        }
    }
}