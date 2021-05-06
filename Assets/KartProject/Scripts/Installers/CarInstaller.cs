using UnityEngine;

namespace KartRace.Installers
{
    public class CarInstaller : MonoBehaviour
    {
        [Header( "Car Elements" )]
        [SerializeField] private Cars.InterfaceAdapters.Controller.CarController car;

        [Header( "Joystick Elements" )]
        [SerializeField] private bool useJoystick;
        //[SerializeField] private Joystick _joystick;
        //[SerializeField] private MOCA.Utils.ButtonPressed _isBreakingButton;

        private void Awake()
        {
            car.Configure( GetInput() );
        }

        private Application.IInput GetInput()
        {
            if( useJoystick )
            {
                //return new TouchInputAdapter( _joystick, _isBreakingButton );
            }
            //Destroy( _joystick.gameObject );
            //Destroy( _isBreakingButton.gameObject );

            return new InterfaceAdapters.UnityInputAdapter();
        }

    }
}