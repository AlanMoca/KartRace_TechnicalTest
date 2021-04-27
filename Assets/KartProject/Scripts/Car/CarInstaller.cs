using UnityEngine;

namespace KartRace.Cars
{
    public class CarInstaller : MonoBehaviour
    {
        [Header( "Car Elements" )]
        [SerializeField] private CarController _car;

        [Header( "Joystick Elements" )]
        [SerializeField] private bool _useJoystick;
        //[SerializeField] private Joystick _joystick;
        //[SerializeField] private MOCA.Utils.ButtonPressed _isBreakingButton;

        private void Awake()
        {
            _car.Configure( GetInput() );
        }

        private IInput GetInput()
        {
            if( _useJoystick )
            {
                //return new TouchInputAdapter( _joystick, _isBreakingButton );
            }
            //Destroy( _joystick.gameObject );
            //Destroy( _isBreakingButton.gameObject );

            return new UnityInputAdapter();
        }

    }
}