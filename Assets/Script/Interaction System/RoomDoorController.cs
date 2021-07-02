using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomDoorController : MonoBehaviour
{
    [SerializeField]
    private string doorName;
    [SerializeField]
    private List<string> orderedListIdsDialogues = new List<string>();
    private List<string> interactedDialogues = new List<string>();

    [SerializeField]
    private bool isOrderRespected = false;

    [SerializeField]
    private InteractedDialogueObject lastInteractedDialogue;

    public UnityEvent signalEvent;

    private DialogueInteractionObject dio;

    public void CheckInteraction()
    {
        dio = lastInteractedDialogue.interracted;
        if (!orderedListIdsDialogues.Contains(dio.id) || isOrderRespected) {return;}

        interactedDialogues.Add(dio.id);
        if(interactedDialogues.Count > orderedListIdsDialogues.Count)
        {
            interactedDialogues.RemoveAt(0);
        }
        if (interactedDialogues.Count == orderedListIdsDialogues.Count)
        {
            CompareLists();
        }
    }

    private void CompareLists()
    {
        for(int i = 0; i < orderedListIdsDialogues.Count; i++)
        {
            if (!interactedDialogues[i].Equals(orderedListIdsDialogues[i]))
            {
                return;
            }
        }

        isOrderRespected = true;
        signalEvent.Invoke();
        Debug.Log("Congrats ! You have finish the room");
    }

    public string GetName()
    {
        return doorName;
    }

    public bool GetOrderRespected()
    {
        return isOrderRespected;
    }

    public void SetOrderRespected(bool value)
    {
        isOrderRespected = value;
    }
}
