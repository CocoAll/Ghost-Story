using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 0.5f;
    [SerializeField]
    private Transform cameraTarget, playerTransform;
    private float mouseX, mouseY;

    private static bool inputEnabled = true;
    private PlayerInput playerInput;
    private Vector2 cameraInputsPressed;

    PlayerInputActions playerInputActions;


    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void LateUpdate()
    {
        if (inputEnabled)
        {
            CameraControl();
        }
    }

    void CameraControl()
    {
        cameraInputsPressed = playerInputActions.Player.Camera.ReadValue<Vector2>();

        //We get the inputs value
        mouseX += cameraInputsPressed.x * rotationSpeed;
        mouseY -= cameraInputsPressed.y * rotationSpeed;

        //Clamp Y so we don't go to far above or under the player
        mouseY = Mathf.Clamp(mouseY, -50, 55);
        transform.LookAt(cameraTarget);
        
        //We apply the rotation to the target (it apply the rotation to the camera too)
        cameraTarget.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        
        //We rotate the player
        playerTransform.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    //Static method to enable or disabled inputs (for cinematics)

    public static void DisableInput(PlayableDirector pd)
    {
        inputEnabled = false;
    }

    public static void EnableInput(PlayableDirector pd)
    {
        inputEnabled = true;
    }
}
