using UnityEngine;
using UnityEngine.Events;

namespace KartRace.Cars
{
    public class CarController : MonoBehaviour
    {
        [Header( "Bahaviour Parameters" )]
        [SerializeField] private float forwardSpeed;
        [SerializeField] private float reverseSpeed;
        [SerializeField] private float turnSpeed;
        [SerializeField] private Rigidbody sphereRB;
        [SerializeField] private LayerMask groundLayer;

        [Header( "Drag" )]
        [SerializeField] private float airDrag;
        [SerializeField] private float groundDrag;

        [Header( "Jump" )]
        [Range( 1f, 1.5f )]
        [SerializeField] float jumpVel = 1.3f;

        [Header( "Boost" )]
        // Disable boost
        [SerializeField] private bool allowBoostFromEditor = true;
        [SerializeField] private float currentboost = 0f;
        [SerializeField] private float maxBoost = 2f;
        [SerializeField] private float boostForce = 100;
        [Range( 0f, 1f )]
        [SerializeField] private float boostRegeneration = 0.2f;

        private float verticalMove;
        private float horizontalMove;
        private bool isCarGrounded;

        private IInput _input;

        
        

        public void Configure( IInput input )
        {
            _input = input;
        }

        private void Start()
        {
            DetachSphereFromCar();
            currentboost = maxBoost;
        }

        private void Update()
        {
            GetInputs();
            GetVerticalDirection();
            GetHorizontalDirection();
            UpdatePositionRespectMovement();
            GroundCheck();
            HandleDrag();
            BoostTimer();

        }

        private void FixedUpdate()
        {
            HandleGravity();
            HandleJump();
            HandleBoost();
        }

        private void DetachSphereFromCar()
        {
            sphereRB.transform.parent = null;
        }

        private void GetInputs()
        {
            verticalMove = _input.GetVerticalDirection();
            horizontalMove = _input.GetHorizontalDirection();
        }

        private void GetVerticalDirection()
        {
            verticalMove *= verticalMove > 0 ? forwardSpeed : reverseSpeed;
        }

        private void GetHorizontalDirection()
        {
            float newRotation = horizontalMove * turnSpeed * Time.deltaTime * _input.GetVerticalDirection();
            transform.Rotate( 0, newRotation, 0, Space.World );
        }

        private void UpdatePositionRespectMovement()
        {
            transform.position = sphereRB.transform.position;
        }

        private void GroundCheck()
        {
            RaycastHit hit;
            isCarGrounded = Physics.Raycast( transform.position, -transform.up, out hit, 1f, groundLayer );
            CarControlParalleltoGround( hit );
        }

        private void CarControlParalleltoGround( RaycastHit hit )
        {
            transform.rotation = Quaternion.FromToRotation( transform.up, hit.normal ) * transform.rotation;
        }

        private void BoostTimer()
        {
            if( allowBoostFromEditor )
            {
                currentboost += Time.deltaTime * boostRegeneration;
                if( currentboost > maxBoost )
                {
                    currentboost = maxBoost;
                }
            }
        }

        private void HandleDrag()
        {
            if( isCarGrounded )
            {
                sphereRB.drag = groundDrag;
            }
            else
            {
                sphereRB.drag = airDrag;
            }
        }

        private void HandleGravity()
        {
            if( isCarGrounded )
            {
                sphereRB.AddForce( transform.forward * verticalMove, ForceMode.Acceleration );
            }
            else
            {
                sphereRB.AddForce( transform.up * -9.81f, ForceMode.Acceleration );
            }
        }

        private void HandleBoost()
        {
            var canUseBoost = _input.GetIfBoosting() && allowBoostFromEditor && currentboost > 0.1f && isCarGrounded;
            if( canUseBoost )
            {
                sphereRB.AddForce( transform.forward * boostForce );

                currentboost -= Time.fixedDeltaTime;
                if( currentboost < 0f )
                {
                    currentboost = 0f;
                }
            }
            
        }

        private void HandleJump()
        {
            if( _input.GetIfJumping() )
            {
                if( !isCarGrounded )
                    return;

                sphereRB.velocity += transform.up * jumpVel;
            }
        }
    }
}
