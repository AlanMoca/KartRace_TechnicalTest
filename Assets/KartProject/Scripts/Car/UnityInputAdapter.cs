using UnityEngine;

namespace KartRace.Cars
{
    public class UnityInputAdapter : IInput
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        private float horizontalInput;
        private float verticalInput;
        private bool isJumping;
        private bool isBoosting;

        public float GetHorizontalDirection()
        {
            horizontalInput = Input.GetAxisRaw( HORIZONTAL );
            return horizontalInput;
        }

        public float GetVerticalDirection()
        {
            verticalInput = Input.GetAxisRaw( VERTICAL );
            return verticalInput;
        }

        public bool GetIfJumping()
        {
            isJumping = Input.GetKey( KeyCode.Space );
            return isJumping;
        }

        public bool GetIfBoosting()
        {
            isBoosting = Input.GetKey( KeyCode.Mouse1 );
            return isBoosting;
        }

    }

}