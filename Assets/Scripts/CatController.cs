using UnityEngine;
using UnityEngine.InputSystem;

public class CatController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public float gravity = -20f;

    public InputActionReference moveAction;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveAction.action.Enable();
    }

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        float horizontal = input.x;
        float vertical = input.y;

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // Ignore camera tilt
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 move = (forward * vertical + right * horizontal).normalized;

        // Rotate cat smoothly in movement direction
        if (move.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(move),
                rotationSpeed * Time.deltaTime
            );
        }

        controller.Move(move * moveSpeed * Time.deltaTime);

        // Gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
