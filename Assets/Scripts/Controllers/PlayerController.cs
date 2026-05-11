using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float rotationSpeed = 720f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.5f;

    private Vector2 moveInput;
    private Vector3 velocity;
    private bool jumpRequested = false;
    private CharacterController controller;
    private Animator anim;
    private Camera _cam;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        _cam = Camera.main;
        if (_cam == null)
            _cam = FindObjectOfType<Camera>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Called by Input System Jump action (bind Space in Input Actions asset)
    void OnJump(InputValue value)
    {
        RequestJump();
    }

    // Called by JumpBtn's OnClick in the Canvas
    public void RequestJump()
    {
        if (controller.isGrounded)
            jumpRequested = true;
    }

    void Update()
    {
        float inputMagnitude = moveInput.magnitude;
        float currentSpeed = walkSpeed;

        // 1. Determine if Running or Walking
        if (inputMagnitude > 0.8f)
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
        Vector3 camForward = _cam != null ? Vector3.ProjectOnPlane(_cam.transform.forward, Vector3.up).normalized : Vector3.forward;
        Vector3 camRight = _cam != null ? Vector3.ProjectOnPlane(_cam.transform.right, Vector3.up).normalized : Vector3.right;
        Vector3 move = camForward * moveInput.y + camRight * moveInput.x;

        if (controller.isGrounded && velocity.y < 0) velocity.y = -2f;

        // Apply jump
        if (jumpRequested && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpRequested = false;
        }

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