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
    private TimelineCinematic cinematic;
    private CinematicManager cm;

    private void Start()
    {
        cm = CinematicManager.Instance;
    }
    public void Interact()
    {
        
        //Check if last interracted object is null or the same as the current
        if (lastInteractedObject.interracted == null || lastInteractedObject.interracted.id != dialogueObject.id)
        {
            lastInteractedObject.interracted = dialogueObject;
        }

        //TODO : Externaliser ça ?
        if (dialogueObject.firstInterraction && cinematic != null && cm != null)
        {
            cm.PlayCinematic(cinematic);
            if (dialogueObject.firstInterraction) dialogueObject.firstInterraction = false;
        }

        interactionSignalSender.Raise();
    }
}
