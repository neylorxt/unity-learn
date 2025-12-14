using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // private PlayerInput _playerInput; // Reference to PlayerInput component.
    private InputSystemActionsPlayer _InputSystemActionsPlayer; // Reference to generated Input Actions class.
    public Camera _FirstPersonCamera; // Reference to the first-person camera.
    public Camera _ThirdPersonCamera; // Reference to the third-person camera.  

    public float speed = 5.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.
    private Rigidbody rb; // Reference to player's Rigidbody.

    // Store movement input.
    private Vector2 _moveInput;

    private void Awake()
    {
        _InputSystemActionsPlayer = new InputSystemActionsPlayer();

        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _InputSystemActionsPlayer.Enable();
    }

    private void OnDisable()
    {
        _InputSystemActionsPlayer.Disable();
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (_InputSystemActionsPlayer!= null)
        {
            _InputSystemActionsPlayer.Player.Jump.performed += OnJump;
            _InputSystemActionsPlayer.Player.SwitchCamera.performed += SwitchCamera;

            _InputSystemActionsPlayer.Player.Move.performed += OnMove;
            _InputSystemActionsPlayer.Player.Move.canceled += OnMoveCancel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        Vector3 movement = transform.forward * _moveInput.y * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        float turn = _moveInput.x * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

    }





    private void SwitchCamera(InputAction.CallbackContext Context)
    {
        if (_FirstPersonCamera.enabled)
        {
            _FirstPersonCamera.enabled = false;
            _ThirdPersonCamera.enabled = true;
        }
        else
        {
            _FirstPersonCamera.enabled = true;
            _ThirdPersonCamera.enabled = false;
        }
    }






    // Handle action. 
    private void OnJump( InputAction.CallbackContext context )
    {
        print("Jump action performed " );
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCancel(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }

}
