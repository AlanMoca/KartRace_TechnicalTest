using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace KartRace.Views.MainMenu
{
    public class MainMenuMediator : MonoBehaviour
    {
        [Header( "Class Instances" )]
        [SerializeField] private Matchs.InterfaceAdapters.Controller.MatchController matchController;
        [SerializeField] private LobbyMenu lobbyMenu;
        [SerializeField] private CustomizerMenu customizerMenu;
        [SerializeField] private ShopMenu shopMenu;
        [SerializeField] private SettingsMenuTabsScreensMediator settingsMenu;
        [SerializeField] private AccountMenu accountMenu;
        [SerializeField] private TransitionBetweenScenes transitionBetweenScenes;

        private Animations.MainMenuAnimations mainMenuAnimations;

        [Header( "UI Elements" )]
        [SerializeField] private Image transitionBetweenMenusImage;
        [SerializeField] private Text sectionText;
        [SerializeField] private Button lobbyMenuButton;
        [SerializeField] private Button customizerMenuButton;
        [SerializeField] private Button shopMenuButton;
        [SerializeField] private Button settingsMenuButton;
        [SerializeField] private Button accountMenuButton;

        [Header( "UI Objects References" )]
        [SerializeField] private Transform car;

        private void Awake()
        {
            mainMenuAnimations = new Animations.MainMenuAnimations( transitionBetweenMenusImage );
            MenusConfiguration();
            AddListenersToPanelbuttons();
        }

        //Aunque la funci�n awake va antes en el flujo de ejecuci�n de Unity que la funci�n OnEnable, se ejecutan de manera "paralela" (fijate que no tiene flecha en el diagrama de unity).
        //Esto quiere decir que si el OnEnable est� activado en un mismo script que el awake como en este, primero ejecutar� el awake e inmediatamente el OnEnable posponiendo el Awake de otros
        //scripts. Una soluci�n es subscribir el evento en el start que s� se ejecuta hasta que todo Awake y OnEnable termine y cumple la misma funci�n porque cada que se ejecuta OnDisable el flujo
        //vuelve a ejecutar Awake-OnEnable -> Start, entonces realmente da lo mismo si se suscribe en OnEnable o Start.
        //La soluci�n que yo hice s�lo para demostrar limpieza de c�digo es permitir que los intallers y principalmente los de servicios acaben primero y luego ejecutar este MainMenuMediator, esto
        //se hizo s�lo cambiando el orden de ejecuci�n de los scripts con el valor por default al agregarlo (300).
        private void OnEnable()
        {
            SuscribeEvents();
        }

        private void Start()
        {
            DOTween.Init();
            LobbyMenu();
            PlayerLoggedInVerification();
        }

        private void OnDisable()
        {
            UnsuscribeEvents();
        }

        public void LobbyMenu()
        {
            DOTween.KillAll();
            mainMenuAnimations.AnimateTransitionBetweenMenus();
            sectionText.text = "Lobby";

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
            sectionText.text = "Customizer";

            lobbyMenu.Hide();
            customizerMenu.Show();
            shopMenu.Hide();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void ShopMenu()
        {
            DOTween.KillAll();
            mainMenuAnimations.AnimateTransitionBetweenMenus();
            sectionText.text = "Shop";

            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Show();
            settingsMenu.Hide();
            accountMenu.Hide();
        }

        public void SettingsMenu()
        {
            DOTween.KillAll();
            mainMenuAnimations.AnimateTransitionBetweenMenus();
            sectionText.text = "Settings";

            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Hide();
            settingsMenu.Show();
            accountMenu.Hide();
        }

        public void AccountMenu()
        {
            DOTween.KillAll();
            mainMenuAnimations.AnimateTransitionBetweenMenus();
            sectionText.text = "Account";

            lobbyMenu.Hide();
            customizerMenu.Hide();
            shopMenu.Hide();
            settingsMenu.Hide();
            accountMenu.Show();
        }

        private void MenusConfiguration()
        {
            lobbyMenu.Configure( this, car, transitionBetweenScenes );
            customizerMenu.Configure( this, car );
            shopMenu.Configure( this, car );
            settingsMenu.Configure( this, car, matchController );
            accountMenu.Configure( this, car );
        }

        private void RemoveAllListenersFromPanelbuttons()
        {
            lobbyMenuButton.onClick.RemoveAllListeners();
            customizerMenuButton.onClick.RemoveAllListeners();
            shopMenuButton.onClick.RemoveAllListeners();
            settingsMenuButton.onClick.RemoveAllListeners();
            accountMenuButton.onClick.RemoveAllListeners();
        }

        private void AddListenersToPanelbuttons()
        {
            lobbyMenuButton.onClick.AddListener( () => LobbyMenu() );
            customizerMenuButton.onClick.AddListener( () => CustomizerMenu() );
            shopMenuButton.onClick.AddListener( () => ShopMenu() );
            settingsMenuButton.onClick.AddListener( () => SettingsMenu() );
            accountMenuButton.onClick.AddListener( () => AccountMenu() );
        }

        private void SuscribeEvents()
        {
            var cloudService = Application.ServiceLocator.Instance.GetService<CloudService.Domain.Entity.ICloudService>();

            cloudService.SubscribeOnLoginSuccessEvent( LobbyMenu );
            cloudService.SubscribeOnLoginSuccessEvent( IsLoggedIn );

            cloudService.SubscribeOnRegisterSuccessEvent( LobbyMenu );
            cloudService.SubscribeOnLogoutSuccessEvent( PlayerLoggedOut );
        }

        private void UnsuscribeEvents()
        {
            var cloudService = Application.ServiceLocator.Instance.GetService<CloudService.Domain.Entity.ICloudService>();

            cloudService.UnsubscribeOnLoginSuccessEvent( LobbyMenu );
            cloudService.UnsubscribeOnLoginSuccessEvent( IsLoggedIn );

            cloudService.UnsubscribeOnRegisterSuccessEvent( LobbyMenu );
            cloudService.UnsubscribeOnLogoutSuccessEvent( PlayerLoggedOut );
        }

        private void IsLoggedIn()
        {
            RemoveAllListenersFromPanelbuttons();
            AddListenersToPanelbuttons();
        }

        private void PlayerLoggedOut()
        {
            RemoveSomeListenersFromPanelbuttonsWhenThePlayerIsNotLogged();
            AddSomeListenersFromPanelbuttonsWhenThePlayerIsNotLogged();
        }

        private void PlayerLoggedInVerification()
        {
            var cloudService = Application.ServiceLocator.Instance.GetService<CloudService.Domain.Entity.ICloudService>();
            if( cloudService.IsLoggedIn() )
            {
                return;
            }
            RemoveSomeListenersFromPanelbuttonsWhenThePlayerIsNotLogged();
            AddSomeListenersFromPanelbuttonsWhenThePlayerIsNotLogged();
        }

        private void RemoveSomeListenersFromPanelbuttonsWhenThePlayerIsNotLogged()
        {
            customizerMenuButton.onClick.RemoveAllListeners();
            shopMenuButton.onClick.RemoveAllListeners();
            settingsMenuButton.onClick.RemoveAllListeners();
        }

        private void AddSomeListenersFromPanelbuttonsWhenThePlayerIsNotLogged()
        {
            customizerMenuButton.onClick.AddListener( () => NotLoggedInYetMessage() );
            shopMenuButton.onClick.AddListener( () => NotLoggedInYetMessage() );
            settingsMenuButton.onClick.AddListener( () => NotLoggedInYetMessage() );
        }

        private void NotLoggedInYetMessage()
        {
            var messageService = Application.ServiceLocator.Instance.GetService<Domain.Entity.IMessage>();
            messageService.MessageToShow( $"You are not logged.\n You need to log in to hace access to this option." );
        }
    }
}