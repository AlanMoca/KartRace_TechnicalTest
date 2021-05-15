using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class MainMenuMediator : MonoBehaviour
    {
        [Header( "Class Instance" )]
        [SerializeField] private LobbyMenu lobbyMenu;
        [SerializeField] private CustomizerMenu customizerMenu;
        [SerializeField] private ShopMenu shopMenu;
        [SerializeField] private SettingsMenu settingsMenu;
        [SerializeField] private AccountMenu accountMenu;

        [Header( "UI Elements" )]
        [SerializeField] private Button lobbyMenuButton;
        [SerializeField] private Button customizerMenuButton;
        [SerializeField] private Button shopMenuButton;
        [SerializeField] private Button settingsMenuButton;
        [SerializeField] private Button accountMenuButton;

        [SerializeField] private ScoreMenu scoreMenu;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private Matchs.InterfaceAdapters.Controller.MatchController matchController;

        private void Awake()
        {
            lobbyMenu.Configure( this );
            customizerMenu.Configure( this );
            shopMenu.Configure( this );
            settingsMenu.Configure( this );
            accountMenu.Configure( this );

            lobbyMenuButton.onClick.AddListener( () => LobbyMenu() );
            customizerMenuButton.onClick.AddListener( () => CustomizerMenu() );
            shopMenuButton.onClick.AddListener( () => ShopMenu() );
            settingsMenuButton.onClick.AddListener( () => SettingsMenu() );
            accountMenuButton.onClick.AddListener( () => AccountMenu() );

            scoreMenu.Configure( this );
        }

        private void Start()
        {
            LobbyMenu();

            scoreMenu.Hide();
        }

        public void LobbyMenu()
        {
            lobbyMenu.Show();
            customizerMenu.Hide();
            shopMenu.Hide();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void CustomizerMenu()
        {
            lobbyMenu.Hide();
            customizerMenu.Show();
            shopMenu.Hide();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void ShopMenu()
        {
            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Show();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void SettingsMenu()
        {
            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Hide();
            settingsMenu.Show();
            accountMenu.Hide();
        }

        public void AccountMenu()
        {
            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Hide();
            settingsMenu.Hide();
            accountMenu.Show();
        }

        public void ScoreMenu()
        {
            scoreMenu.Show( matchController );
            mainMenu.SetActive( false );
        }

        public void MainMenu()
        {
            scoreMenu.Hide();
            mainMenu.SetActive( true );
        }
    }
}



//using UnityEngine;

//namespace KartRace.Views.MainMenu
//{
//    public class MainMenuMediator : MonoBehaviour
//    {
//        [SerializeField] private ScoreMenu scoreMenu;
//        [SerializeField] private GameObject mainMenu;
//        [SerializeField] private Matchs.InterfaceAdapters.Controller.MatchController matchController;

//        private void Awake()
//        {
//            scoreMenu.Configure( this );
//        }

//        private void Start()
//        {
//            scoreMenu.Hide();
//        }

//        public void ScoreMenu()
//        {
//            scoreMenu.Show( matchController );
//            mainMenu.SetActive( false );
//        }

//        public void MainMenu()
//        {
//            scoreMenu.Hide();
//            mainMenu.SetActive( true );
//        }
//    }
//}

