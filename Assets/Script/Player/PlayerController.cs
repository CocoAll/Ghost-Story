using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1.0f;
    [SerializeField]
    private BooleanValue canInteract;

    private static bool inputEnabled = true;
    private SphereCollider collider;
    private Rigidbody rigidbody;
    private PlayerInput playerInput;
    PlayerInputActions playerInputActions;

    private Vector2 movementInputsPressed;

    private void Awake()
    {
        // Retrieve necessary components for player functionality
        collider = GetComponent<SphereCollider>();
        rigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interaction.performed += PlayerInput;
    }

    // Update is called once per frame
    void Update()
    {
        // Manage player movement and player inputs
        PlayerMovement();
        //PlayerInput();
    }

    // Handle player movement
    private void PlayerMovement()
    {
        movementInputsPressed = playerInputActions.Player.Movement.ReadValue<Vector2>();

        // Stop player rotation if in motion
        if (rigidbody.angularVelocity != Vector3.zero)
        {
            rigidbody.angularVelocity = Vector3.zero;
        }

        // Check if player inputs are enabled
        if (inputEnabled)
        {
            // Check if the player is actually moving
            if (movementInputsPressed.x != 0 || movementInputsPressed.y != 0)
            {
                // Calculate player movement direction
                Vector3 playerMovementDirection = new Vector3(movementInputsPressed.x, 0f, movementInputsPressed.y).normalized;

                // Perform collision check before moving the player
                RaycastHit hit;
                if (!Physics.SphereCast(transform.position, collider.radius,
                    Vector3.Scale(this.transform.forward, playerMovementDirection), out hit, (Time.deltaTime * movementSpeed)))
                {
                    // Move the player based on the movement direction and movement speed
                    transform.Translate(playerMovementDirection * Time.deltaTime * movementSpeed, Space.Self);
                }
            }
        }
    }

    // Handle player inputs
    private void PlayerInput(InputAction.CallbackContext context)
    {
        // Check if player inputs are enabled, if they can interact, and if the mouse button is pressed
        if (inputEnabled && canInteract.value)
        {
            // Call the interaction function of the detection zone controller
            DetectionZoneController.DoInteraction();
        }
    }

    /*
     * Static methods to enable or disable inputs (for cinematics)
     */
    public static void DisableInput(PlayableDirector pd)
    {
        // Disable player inputs
        inputEnabled = false;
    }

    public static void EnableInput(PlayableDirector pd)
    {
        // Enable player inputs
        inputEnabled = true;
    }
}