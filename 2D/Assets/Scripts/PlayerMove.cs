using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    public Rigidbody2D playerRigidbody;
    public LayerMask groundLayer;
    public Animator playerAnimator;
    public SpriteRenderer playerSpriteRenderer;

    // PLAYER MOVEMENT VARIABLES
    private Vector3 velocity = Vector3.zero;
    public float moveSpeed = 250f;
    public float jumpForce = 5f;

    // private bool isJumping = false;

    // GROUND CHECK VARIABLES
    private bool isGrounded = true;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;


    void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    void OnDisable()
    {
        _inputActions.Player.Jump.performed -= OnJumpCallback;
        _inputActions.Player.Disable();
    }

    void OnJumpCallback(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        OnJump();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if( playerRigidbody == null )
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
        }

        if( _inputActions != null )
        {
            _inputActions.Player.Jump.performed += ctx => OnJump();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = _inputActions.Player.Move.ReadValue<Vector2>().x * moveSpeed * Time.deltaTime;

        Collider2D hit = Physics2D.OverlapArea(
            groundCheckLeft.position,
            groundCheckRight.position,
            groundLayer
        );

        isGrounded = hit != null;

        MovePlayer(moveHorizontal);

        // Change direction du sprite en fonction de la direction du mouvement
        Flip(playerRigidbody.linearVelocity.x);

        float characterVelocityX = Math.Abs(playerRigidbody.linearVelocity.x);
        playerAnimator.SetFloat("speed", characterVelocityX);
    }

    void MovePlayer(float moveHorizontal)
    {
        Vector2 v = playerRigidbody.linearVelocity;
        v.x = moveHorizontal;
        playerRigidbody.linearVelocity = v; // On ne touche pas v.y pour garder le saut.
    }

    // ACTION METHODS
    public void OnJump()
    {
        if (isGrounded)
        {
            // isJumping = true;

            Vector2 v = playerRigidbody.linearVelocity;
            v.y = 0f; // optionnel, pour avoir un saut clean
            playerRigidbody.linearVelocity = v;

            playerRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Flip( float velocityX )
    {
        if ( velocityX > 0.1f )
        {
            playerSpriteRenderer.flipX = false;
        }
        else if ( velocityX < -0.1f )
        {
            playerSpriteRenderer.flipX = true;
        }
    }
}
