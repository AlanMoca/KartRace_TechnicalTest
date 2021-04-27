using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header( "Bahaviour Parameters" )]
    public float forwardSpeed;
    public float reverseSpeed;
    public float turnSpeed;

    [Header( "Drag" )]
    public float airDrag;
    public float groundDrag;

    [Header( "Jump" )]
    [Range( 1f, 1.5f )]
    [SerializeField] float jumpVel = 1.3f;

    [Header( "Boost" )]
    // Disable boost
    [SerializeField] private bool allowBoost = true;
    [SerializeField] private float boost = 10f;
    [SerializeField] private float maxBoost = 4f;
    [SerializeField] private float boostForce = 100;
    [Range( 0f, 1f )]
    [SerializeField] private float boostRegen = 0.2f;
    [SerializeField] private bool boosting = false;

    private float moveInput;
    private float turnInput;

    private bool jumping = false;
    private bool isCarGrounded;

    public LayerMask groundLayer;

    public Rigidbody sphereRB;

    private void Start()
    {
        DetachSphereFromCar();
        boost = maxBoost;
    }

    private void Update()
    {
        Inputs();
        GetVerticalDirection();
        UpdatePositionRespectMovement();

        GetHorizontalDirection();

        GroundCheck();

        HandleDrag();
        BoostTimer();

    }

    private void FixedUpdate()
    {
        HandleGravity();    //???
        HandleJump();
        HandleBoost();
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

    private void DetachSphereFromCar()
    {
        sphereRB.transform.parent = null;
    }

    private void Inputs()
    {
        moveInput = Input.GetAxisRaw( "Vertical" );
        turnInput = Input.GetAxisRaw( "Horizontal" );
        jumping = Input.GetAxis( "Jump" ) != 0;
        boosting = ( Input.GetAxis( "Fire2" ) > 0.5f );
    }

    private void GetVerticalDirection()
    {
        moveInput *= moveInput > 0 ? forwardSpeed : reverseSpeed;
    }

    private void GetHorizontalDirection()
    {
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw( "Vertical" );
        transform.Rotate( 0, newRotation, 0, Space.World );
    }

    private void UpdatePositionRespectMovement()
    {
        transform.position = sphereRB.transform.position;
    }

    private void BoostTimer()
    {
        if( allowBoost )
        {
            boost += Time.deltaTime * boostRegen;
            if( boost > maxBoost )
            {
                boost = maxBoost;
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
            sphereRB.AddForce( transform.forward * moveInput, ForceMode.Acceleration );
        }
        else
        {
            sphereRB.AddForce( transform.up * -9.81f, ForceMode.Acceleration );
        }
    }

    private void HandleBoost()
    {
        if( boosting && allowBoost && boost > 0.1f && isCarGrounded )
        {
            sphereRB.AddForce( transform.forward * boostForce );

            boost -= Time.fixedDeltaTime;
            if( boost < 0f )
            {
                boost = 0f;
            }
        }
    }

    private void HandleJump()
    {
        if( jumping )
        {
            if( !isCarGrounded )
                return;

            sphereRB.velocity += transform.up * jumpVel;
        }
    }




}
