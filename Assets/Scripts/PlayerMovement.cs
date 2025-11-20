using Unity.VisualScripting;
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
    public float BaseJumpForce;
    public float Direction;
    public bool isGrounded;
    public float coyoteTimer;
    public float lagJumpTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
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
                lagJumpTimer = 0;
            }
            if (lagJumpTimer <= 0)
            {
                lagJumpTimer = 0;
            }
        }
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
        }
        else
        {
            Direction = 0;
        }
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if(!ctx.canceled && isGrounded)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        else if (!ctx.canceled && !isGrounded)
        {
            lagJumpTimer = 0.125f;
        }
        else if (ctx.canceled)
        {
            rig.AddForce(new Vector2(0f, -JumpForce), ForceMode2D.Impulse);
        }
    }
    public void Sprint(InputAction.CallbackContext ctx)
    {
        if (!ctx.canceled)
        {
            PlayerSpeed = PlayerSpeed * 1.25f;
            JumpForce = JumpForce * 0.95f;
        }
        if (ctx.canceled)
        {
            PlayerSpeed = BasePlayerSpeed;
            JumpForce = BaseJumpForce;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && rig.linearVelocityY == 0f)
        {
            isGrounded = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && rig.linearVelocityY == 0f)
        {
            isGrounded = true;
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

