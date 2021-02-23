using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotationAction : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Vector3 rotationAngle;

    private bool shouldRotate = false;

    private void Update()
    {
        if(shouldRotate && this.transform.rotation.eulerAngles!= rotationAngle)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(rotationAngle), Time.deltaTime * rotationSpeed);
        }
    }

    public void RotateDoor()
    {
        shouldRotate = true;
    }
}
