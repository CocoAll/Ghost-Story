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
    [SerializeField]
    private BooleanValue inputsEnabled;

    private SphereCollider collider;
    private Rigidbody rigidbody;
    PlayerInputActions playerInputActions;

    private Vector2 movementInputsPressed;

    private void Awake()
    {
        // Retrieve necessary components for player functionality
        collider = GetComponent<SphereCollider>();
        rigidbody = GetComponent<Rigidbody>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interaction.performed += PlayerInput;
    }

    // Update is called once per frame
    void Update()
    {
        // Manage player movement and player inputs
        PlayerMovement();
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
        if (inputsEnabled.value)
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

    // Handle player inputs (TODO : Rename because it just handle click ?)
    private void PlayerInput(InputAction.CallbackContext context)
    {
        // Check if player inputs are enabled, if they can interact, and if the mouse button is pressed
        if (inputsEnabled.value && canInteract.value)
        {
            // Call the interaction function of the detection zone controller
            DetectionZoneController.DoInteraction();
        }
    }
}