using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Classe contenant les informations de l'état de la pièce.
 */
public class RoomState : MonoBehaviour
{
    [SerializeField]
    private EnumRoomState state = EnumRoomState.HIDDEN;
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private GameObject interactableParent;

    public Transform StartPosition { get => startPosition; set => startPosition = value; }
    public EnumRoomState State { get => state; set => state = value; }
    public GameObject InteractableParent { get => interactableParent; set => interactableParent = value; }
}

public enum EnumRoomState
{
    HIDDEN,
    CURRENT,
    FINISHED
}
