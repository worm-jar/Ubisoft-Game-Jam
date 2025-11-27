using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset action;
    public InputAction Player;
    public InputActionReference MoveRef;
    public InputActionReference JumpRef;
    public InputActionReference SprintRef;
    public Rigidbody2D rig;
    public float PlayerSpeed;
    public float JumpForce;
    public float BasePlayerSpeed;
    public static Vector2 Position;
    public float BaseJumpForce;
    public float Direction;
    public bool isGrounded;
    public float coyoteTimer;
    public float lagJumpTimer;
    public Animator playerAnimator;
    public float WalkStopTimer;
    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        if(rig.linearVelocityY < 0f)
        {
            playerAnimator.SetTrigger("JumpDown");
        }
        rig.linearVelocity = new Vector2(Direction * PlayerSpeed * Time.deltaTime, rig.linearVelocityY);

        MoveRef.action.started += Move;
        MoveRef.action.performed += Move;
        MoveRef.action.canceled += Move;
        
        JumpRef.action.started += Jump;
        JumpRef.action.canceled += Jump;

        SprintRef.action.started += Sprint;
        SprintRef.action.performed += Sprint;
        SprintRef.action.canceled += Sprint;
    }
    void Update()
    {
        float swapSide = Input.GetAxisRaw("Horizontal");
        if (swapSide < 0 && facingRight)
            Flip();
        else if (swapSide > 0 && !facingRight)
            Flip();



        if (coyoteTimer > 0)
        {
            coyoteTimer -= Time.deltaTime;
            isGrounded = true;
            if (coyoteTimer <= 0)
            {
                isGrounded = false;
                coyoteTimer = 0;
            }
        }
        
        if (lagJumpTimer > 0)
        {
            lagJumpTimer -= Time.deltaTime;
            if(isGrounded)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                playerAnimator.SetTrigger("JumpUp");
                lagJumpTimer = 0;
            }
            if (lagJumpTimer <= 0)
            {
                lagJumpTimer = 0;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void OnEnable()
    { 
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        if (!ctx.canceled)
        {
            Direction = ctx.ReadValue<float>();
            playerAnimator.SetTrigger("IsWalking");
            //CameraMovement.ChaseSequence = true;
        }
        else
        {
            Direction = 0;
            playerAnimator.SetTrigger("StopWalking");
            //CameraMovement.ChaseSequence = false;
        }
        //Position = (rig.position);
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if(!ctx.canceled && isGrounded)
        {
            playerAnimator.SetTrigger("JumpUp");
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        else if (!ctx.canceled && !isGrounded)
        {
            lagJumpTimer = 0.125f;
        }
        else if (ctx.canceled)
        {
            playerAnimator.SetTrigger("JumpDown");
            rig.AddForce(new Vector2(0f, -JumpForce), ForceMode2D.Impulse);
        }
    }
    public void Sprint(InputAction.CallbackContext ctx)
    {
        if (!ctx.canceled)
        {
            PlayerSpeed = PlayerSpeed * 1.25f;
            JumpForce = JumpForce * 0.95f;
            playerAnimator.SetTrigger("IsRunning");
        }
        if (ctx.canceled)
        {
            PlayerSpeed = BasePlayerSpeed;
            JumpForce = BaseJumpForce;
            playerAnimator.SetTrigger("StopRunning");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && rig.linearVelocityY == 0f)
        {
            isGrounded = true;
            playerAnimator.SetTrigger("IsGrounded");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && rig.linearVelocityY == 0f)
        {
            isGrounded = true;
            playerAnimator.SetTrigger("IsGrounded");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && rig.linearVelocityY >= 0)
        {
            isGrounded = false;
        }
        else if (collision.gameObject.CompareTag("Ground") && rig.linearVelocityY < 0)
        {
            coyoteTimer = 0.1f;
        }
    }
}

