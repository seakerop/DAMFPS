using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float forceValue = 5;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float gravityValue = -10;



    private InputAction moveAction;
    private InputAction jumpAction;
    private CharacterController controller;
    private bool groundedPlayer;
    private Vector3 velocity;



    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        controller = GetComponent<CharacterController>();
    }


    void Update()
    {
        groundedPlayer = controller.isGrounded;
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        bool jumpValue = jumpAction.IsPressed();

        Vector3 cameraForward = transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 cameraRight = transform.right;
        cameraRight.y = 0f;
        cameraRight.Normalize();

        Vector3 moveDirection = cameraForward * moveValue.y + cameraRight * moveValue.x;
        velocity.x = moveDirection.x * forceValue;
        velocity.z = moveDirection.z * forceValue;


        if (groundedPlayer)
        {
            velocity.y = 0;
        }

        if (jumpAction.IsPressed() && groundedPlayer)
        {
            velocity.y += jumpForce;
        }

        velocity.y += gravityValue * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);

    }
}
