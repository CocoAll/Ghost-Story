using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InterractionButtonController : MonoBehaviour
{
    [SerializeField]
    private BooleanValue canInteract;
    [SerializeField]
    private Image interractionImage;

    private void Start()
    {
        canInteract.value = false;
        interractionImage.enabled = false;
    }

    public void CanInteractSignal()
    {
        interractionImage.enabled = canInteract.value;
    }

    public void InteractionSignal()
    {
        canInteract.value = false;
        interractionImage.enabled = false;
    }
}
