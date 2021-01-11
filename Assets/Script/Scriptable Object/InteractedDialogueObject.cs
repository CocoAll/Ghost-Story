using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interracted Dialogue Object", menuName = "Scriptable Object/InteractedDialogueObject", order = 2)]
public class InteractedDialogueObject : ScriptableObject
{
    public DialogueInteractionObject interracted;
}
