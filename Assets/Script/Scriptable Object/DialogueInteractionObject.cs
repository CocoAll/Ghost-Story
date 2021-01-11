using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Object", menuName = "Scriptable Object/DialogueInteractionObject", order = 1)]
public class DialogueInteractionObject : ScriptableObject
{
    public string id;
    public string text;
    public AudioClip dialogue;
    public bool firstInterraction = true;
}
