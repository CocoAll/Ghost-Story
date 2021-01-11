using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1.0f;
    [SerializeField]
    private BooleanValue canInteract;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerInput();
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(horizontalInput != 0 || verticalInput != 0){
            Vector3 playerMovementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            transform.Translate(playerMovementDirection * Time.deltaTime * movementSpeed, Space.Self);
        } 
    }

    private void PlayerInput()
    {
        if (canInteract.value && Input.GetKeyDown(KeyCode.Mouse0))
        {
            DetectionZoneController.getIoc().Interact();
        }
    }
}
