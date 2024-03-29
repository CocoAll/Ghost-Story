﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Start()
    {
        collider = GetComponent<SphereCollider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerInput();
    }

    private void PlayerMovement()
    {
        if(rigidbody.angularVelocity != Vector3.zero)
        {
            rigidbody.angularVelocity = Vector3.zero;
        }

        if (inputEnabled)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            if(horizontalInput != 0 || verticalInput != 0){
                Vector3 playerMovementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
                RaycastHit hit;
                if (!Physics.SphereCast(transform.position, collider.radius, 
                    Vector3.Scale(this.transform.forward,playerMovementDirection), out hit, (Time.deltaTime * movementSpeed)))
                {
                    transform.Translate(playerMovementDirection * Time.deltaTime * movementSpeed, Space.Self);
                }
            } 
        }
    }

    private void PlayerInput()
    {
        if (inputEnabled && canInteract.value && Input.GetKeyDown(KeyCode.Mouse0))
        {
            DetectionZoneController.getIoc().Interact();
        }
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
