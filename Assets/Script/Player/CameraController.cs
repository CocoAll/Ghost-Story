using UnityEngine;
using UnityEngine.Playables;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1.0f;
    [SerializeField]
    private Transform cameraTarget, playerTransform;
    private float mouseX, mouseY;

    private static bool inputEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        //We get the inputs value
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
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
