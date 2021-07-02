using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InteractableObjectController : MonoBehaviour
{
    [SerializeField]
    private DialogueInteractionObject dialogueObject;
    [SerializeField]
    private SignalSender interactionSignalSender;
    [SerializeField]
    private InteractedDialogueObject lastInteractedObject;
    [SerializeField]
    private PlayableDirector playableDirector;

    public void Interact()
    {
        
        //Check if last interracted object is null or the same as the current
        if (lastInteractedObject.interracted == null || lastInteractedObject.interracted.id != dialogueObject.id)
        {
            lastInteractedObject.interracted = dialogueObject;
        }

        //TODO : Externaliser ça ?
        if (dialogueObject.firstInterraction && playableDirector != null)
        {
            playableDirector.Play();
            dialogueObject.firstInterraction = false;
        }

        interactionSignalSender.Raise();
    }
}
