using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float rotationSpeed = 720f;
    public float gravity = -9.81f;

    private Vector2 moveInput;
    private Vector3 velocity;
    private CharacterController controller;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        float inputMagnitude = moveInput.magnitude;
        float currentSpeed = walkSpeed;

        // 1. Determine if Running or Walking
        // Change this line in your Update() function:
        if (inputMagnitude > 0.8f) // Lowered from 0.9f
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
        }
        else if (inputMagnitude > 0.1f)
        {
            currentSpeed = walkSpeed;
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }

        // 2. Move and Rotate
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        
        if (controller.isGrounded && velocity.y < 0) velocity.y = -2f;
        velocity.y += gravity * Time.deltaTime;

        controller.Move(move * currentSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);

        if (move.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}