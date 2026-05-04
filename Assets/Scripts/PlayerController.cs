using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 moveInput;
    private Rigidbody rb;

    void Start()
    {
        // This finds the physics body on your player
        rb = GetComponent<Rigidbody>();
    }

    // This runs automatically when the joystick moves
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        // This tells the physics body to move in the direction of the joystick
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        rb.linearVelocity = move * speed;
    }
}