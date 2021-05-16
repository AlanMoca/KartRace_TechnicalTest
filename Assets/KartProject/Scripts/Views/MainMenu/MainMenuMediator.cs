using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        [SerializeField] private Image transitionBetweenMenusImage;
        [SerializeField] private Button lobbyMenuButton;
        [SerializeField] private Button customizerMenuButton;
        [SerializeField] private Button shopMenuButton;
        [SerializeField] private Button settingsMenuButton;
        [SerializeField] private Button accountMenuButton;

        [Header( "UI 3D Elements" )]
        [SerializeField] private Transform car;

        [SerializeField] private ScoreMenu scoreMenu;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private Matchs.InterfaceAdapters.Controller.MatchController matchController;

        private void Awake()
        {
            lobbyMenu.Configure( this, car );
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
            AnimateTransitionBetweenMenus();
            lobbyMenu.Show();
            customizerMenu.Hide();
            shopMenu.Hide();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void CustomizerMenu()
        {
            DOTween.KillAll();
            AnimateTransitionBetweenMenus();
            lobbyMenu.Hide();
            customizerMenu.Show();
            shopMenu.Hide();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void ShopMenu()
        {
            AnimateTransitionBetweenMenus();
            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Show();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void SettingsMenu()
        {
            AnimateTransitionBetweenMenus();
            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Hide();
            settingsMenu.Show();
            accountMenu.Hide();
        }

        public void AccountMenu()
        {
            AnimateTransitionBetweenMenus();
            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Hide();
            settingsMenu.Hide();
            accountMenu.Show();
        }

        private void AnimateTransitionBetweenMenus()
        {
            var transparentColor = transitionBetweenMenusImage.color;
            var opaqueColor = transitionBetweenMenusImage.color;
            opaqueColor.a = 1;

            var backgoundSequence = DOTween.Sequence();

            backgoundSequence.
                Append( transitionBetweenMenusImage.DOColor( opaqueColor, 0.05f ) ).
                Append( transitionBetweenMenusImage.DOColor( transparentColor, 0.05f ) );
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

