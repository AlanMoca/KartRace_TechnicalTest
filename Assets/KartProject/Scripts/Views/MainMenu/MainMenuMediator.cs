using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class MainMenuMediator : MonoBehaviour
    {
        [Header( "Class Instance" )]
        [SerializeField] private Matchs.InterfaceAdapters.Controller.MatchController matchController;
        [SerializeField] private LobbyMenu lobbyMenu;
        [SerializeField] private CustomizerMenu customizerMenu;
        [SerializeField] private ShopMenu shopMenu;
        [SerializeField] private SettingsMenu settingsMenu;
        [SerializeField] private AccountMenu accountMenu;
        [SerializeField] private TransitionBetweenScenes transitionBetweenScenes;

        private Animations.MainMenuAnimations mainMenuAnimations;

        [Header( "UI Elements" )]
        [SerializeField] private Image transitionBetweenMenusImage;
        [SerializeField] private Button lobbyMenuButton;
        [SerializeField] private Button customizerMenuButton;
        [SerializeField] private Button shopMenuButton;
        [SerializeField] private Button settingsMenuButton;
        [SerializeField] private Button accountMenuButton;

        [Header( "UI Objects References" )]
        [SerializeField] private Transform car;

        [SerializeField] private ScoreMenu scoreMenu;
        [SerializeField] private GameObject mainMenu;
        

        private void Awake()
        {
            mainMenuAnimations = new Animations.MainMenuAnimations( transitionBetweenMenusImage );

            lobbyMenu.Configure( this, car, transitionBetweenScenes );
            customizerMenu.Configure( this, car );
            shopMenu.Configure( this, car );
            settingsMenu.Configure( this, car );
            accountMenu.Configure( this, car );

            lobbyMenuButton.onClick.AddListener( () => LobbyMenu() );
            customizerMenuButton.onClick.AddListener( () => CustomizerMenu() );
            shopMenuButton.onClick.AddListener( () => ShopMenu() );
            settingsMenuButton.onClick.AddListener( () => SettingsMenu() );
            accountMenuButton.onClick.AddListener( () => AccountMenu() );

            scoreMenu.Configure( this );
        }

        private void Start()
        {
            DOTween.Init();
            LobbyMenu();

            scoreMenu.Hide();
        }

        public void LobbyMenu()
        {
            DOTween.KillAll();
            mainMenuAnimations.AnimateTransitionBetweenMenus();

            lobbyMenu.Show();
            customizerMenu.Hide();
            shopMenu.Hide();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void CustomizerMenu()
        {
            DOTween.KillAll();
            mainMenuAnimations.AnimateTransitionBetweenMenus();

            lobbyMenu.Hide();
            customizerMenu.Show();
            shopMenu.Hide();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void ShopMenu()
        {
            mainMenuAnimations.AnimateTransitionBetweenMenus();

            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Show();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void SettingsMenu()
        {
            mainMenuAnimations.AnimateTransitionBetweenMenus();

            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Hide();
            settingsMenu.Show( matchController );
            accountMenu.Hide();
        }

        public void AccountMenu()
        {
            mainMenuAnimations.AnimateTransitionBetweenMenus();

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

