using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    [SerializeField] private float sensitivityMouse = 1.7f;


    private InputAction mouseAction;
    private float rotationX = 0;
    private Transform playerBody;


    void Start()
    {
        mouseAction = InputSystem.actions.FindAction("Look");
        playerBody = transform.parent;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveCamera = mouseAction.ReadValue<Vector2>();
        rotationX -= moveCamera.y * sensitivityMouse * 0.1f;
    

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

       playerBody.Rotate(Vector3.up * moveCamera.x * sensitivityMouse * 0.1f);
    }
}
