using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace KartRace.Views.MainMenu.Input
{
    //It is a class developed just to exemplify how to use "the tab key" navigation between the elements of the ui.
    public class InputUINavigation
    {
        private EventSystem system;
        private Selectable firstInput;
        private Button submitButton;

        public InputUINavigation( Selectable _firstInput, Button _submitButton )
        {
            firstInput = _firstInput;
            submitButton = _submitButton;
            system = EventSystem.current;
            firstInput.Select();
        }

        public void GetInputUser()
        {
            //These statics calls of the input class should be replaced by calls from service locator that communicates with an adapter to facilitate testing.
            if( UnityEngine.Input.GetKeyDown( KeyCode.Tab ) && UnityEngine.Input.GetKey( KeyCode.LeftShift ) )
            {
                //It should be left like this because it gets the current object in real time.
                Selectable previous = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
                if( previous != null )
                {
                    previous.Select();
                }
            }
            else if( UnityEngine.Input.GetKeyDown( KeyCode.Tab ) )
            {
                //It should be left like this because it gets the current object in real time.
                Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                if( next != null )
                {
                    next.Select();
                }
            }
            else if( UnityEngine.Input.GetKeyDown( KeyCode.Return ) )
            {
                submitButton.onClick.Invoke();
            }
        }
    }
}