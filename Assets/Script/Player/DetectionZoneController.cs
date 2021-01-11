using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZoneController : MonoBehaviour
{
    [SerializeField]
    private BooleanValue canInteract;
    [SerializeField]
    private SignalSender canInteractSignal;

    private static InteractableObjectController ioc;

    public static InteractableObjectController getIoc()
    {
        return ioc;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactable")
        {
            canInteract.value = true;
            canInteractSignal.Raise();
            ioc = other.gameObject.GetComponent<InteractableObjectController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            canInteract.value = false;
            canInteractSignal.Raise();
            ioc = null;
        }
    }

    private void DoInteraction(GameObject gameObject)
    {
        if (gameObject == null) return;
        gameObject.GetComponent<InteractableObjectController>().Interact();
    }
}
