using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset action;
    public InputAction Player;
    public InputActionReference MoveRef;
    public Rigidbody2D rig;
    public float PlayerSpeed;
    public float Direction;
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
    }
    void Update()
    {

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

}

