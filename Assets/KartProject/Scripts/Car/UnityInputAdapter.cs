using UnityEngine;

namespace KartRace.Cars
{
    public class UnityInputAdapter : IInput
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private float _horizontalInput;
        private float _verticalInput;
        private bool _isJumping;
        private bool _isBoosting;

        public float GetHorizontalDirection()
        {
            _horizontalInput = Input.GetAxisRaw( HORIZONTAL );
            return _horizontalInput;
        }

        public float GetVerticalDirection()
        {
            _verticalInput = Input.GetAxisRaw( VERTICAL );
            return _verticalInput;
        }

        public bool GetIfJumping()
        {
            _isJumping = Input.GetKey( KeyCode.Space );
            return _isJumping;
        }

        public bool GetIfBoosting()
        {
            _isBoosting = Input.GetKey( KeyCode.Mouse1 );
            return _isBoosting;
        }

    }

}