using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectController : MonoBehaviour
{
    [SerializeField]
    private DialogueInteractionObject dialogueObject;
    [SerializeField]
    private SignalSender interactionSignalSender;
    [SerializeField]
    private InteractedDialogueObject lastInteractedObject;

    public void Interact()
    {
        //Check if last interracted object is null or the same as the current
        if(lastInteractedObject.interracted == null || lastInteractedObject.interracted.id != dialogueObject.id)
        {
            lastInteractedObject.interracted = dialogueObject;
        }
        interactionSignalSender.Raise();
    }
}
