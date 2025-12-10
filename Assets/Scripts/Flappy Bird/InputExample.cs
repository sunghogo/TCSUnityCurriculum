using UnityEngine;
using UnityEngine.InputSystem;
public class InputExample : MonoBehaviour
{
    public Rigidbody2D rb;
    public InputAction jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        rb.linearVelocityY = 5f;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // if (Input.GetMouseButton(0))
        // {
        //     rb.linearVelocityY = 5f;
        // }
        // if (jumpAction.IsPressed())
        // {
        //     rb.linearVelocityY = 5f;
        // }

    }
}
