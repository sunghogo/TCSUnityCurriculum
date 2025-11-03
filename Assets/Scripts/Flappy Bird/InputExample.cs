using UnityEngine;
using UnityEngine.InputSystem;
public class InputExample : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public InputAction jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        rigidbody.linearVelocityY = 5f;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // if (Input.GetMouseButton(0))
        // {
        //     rigidbody.linearVelocityY = 5f;
        // }
        // if (jumpAction.IsPressed())
        // {
        //     rigidbody.linearVelocityY = 5f;
        // }

    }
}
