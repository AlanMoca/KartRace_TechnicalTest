using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class AccountMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private GameObject loginScreen;
        [SerializeField] private GameObject loggedScreen;
        [SerializeField] private InputField mailInputField;
        [SerializeField] private InputField passwordInputField;
        [SerializeField] private Button loginButton;
        [SerializeField] private Button registerButton;
        [SerializeField] private Button resetPasswordButton;
        [SerializeField] private Button logoutButton;
        [SerializeField] private Text messageText;

        [Header( "UI Objects Reference" )]
        [SerializeField] private GameObject accountMenu;
        [SerializeField] private Transform desiredCarPosition;

        private Transform carTransform;

        //Class instance
        private MainMenuMediator mediator;
        private Animations.AccountMenuAnimations accountMenuAnimations;
        private Input.InputUINavigation inputUINavigation;

        public void Configure( MainMenuMediator menuMediator, Transform _car )
        {
            mediator = menuMediator;
            carTransform = _car;
            inputUINavigation = new Input.InputUINavigation( mailInputField, loginButton );
            accountMenuAnimations = new Animations.AccountMenuAnimations( carTransform, desiredCarPosition );

            registerButton.onClick.AddListener( () => RegisterButton() );
            loginButton.onClick.AddListener( () => LoginButton() );
            logoutButton.onClick.AddListener( () => LogoutButton() );
        }

        private void OnEnable()
        {
            var cloudService = Application.ServiceLocator.Instance.GetService<CloudService.Domain.Entity.ICloudService>();
            if( !cloudService.IsLoggedIn() )
            {
                loginScreen.SetActive( true );
                return;
            }
            loggedScreen.SetActive( true );
            loginScreen.SetActive( false );
        }

        private void Update()
        {
            inputUINavigation.GetInputUser();
        }

        public void Show()
        {
            accountMenu.SetActive( true );

            if( carTransform == desiredCarPosition )
            {
                return;
            }

            accountMenuAnimations.AnimateCarPosition();

        }

        public void Hide()
        {
            accountMenu.SetActive( false );
        }

        public void MessageFeedback( string message )
        {
            messageText.text = message;
        }

        private void RegisterButton()
        {
            var cloudService = Application.ServiceLocator.Instance.GetService<CloudService.Domain.Entity.ICloudService>();
            cloudService.Register( mailInputField.text, passwordInputField.text );
        }

        private void LoginButton()
        {
            var cloudService = Application.ServiceLocator.Instance.GetService<CloudService.Domain.Entity.ICloudService>();
            cloudService.Login( mailInputField.text, passwordInputField.text );
        }

        private void LogoutButton()
        {
            loginScreen.SetActive( true );
            loggedScreen.SetActive( false );
            var cloudService = Application.ServiceLocator.Instance.GetService<CloudService.Domain.Entity.ICloudService>();
            cloudService.Logout();
        }
    }
}