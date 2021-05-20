using UnityEngine;
using UnityEngine.UI;

namespace KartRace.Views.MainMenu
{
    public class AccountMenu : MonoBehaviour
    {
        [Header( "UI Elements" )]
        [SerializeField] private InputField mailInputField;
        [SerializeField] private InputField passwordInputField;
        [SerializeField] private Button loginButton;
        [SerializeField] private Button registerButton;
        [SerializeField] private Button resetPasswordButton;
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
    }
}