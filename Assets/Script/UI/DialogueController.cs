using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private InteractedDialogueObject lastInteractedDialogue;
    [SerializeField]
    private Text dialogueUIText;
    [SerializeField]
    private GameObject dialogueGameObject;
    [SerializeField]
    private AudioSource dialogueAudioSource;

    private LocalizationManager localizationManager;

    private float defaultDialogueSwitchTime = 1.5f;

    private Coroutine PlayDialogueTextCoroutine;

    private void Awake()
    {
        localizationManager = this.GetComponent<LocalizationManager>();
        dialogueUIText.text = "";
        dialogueGameObject.SetActive(false);
    }

    public void PlayDialogue()
    {
        if(PlayDialogueTextCoroutine != null)
        {
            StopCoroutine(PlayDialogueTextCoroutine);
        }

        //https://www.youtube.com/watch?v=HaGkk60kcjQ (ça sert a rien mais ça me fait rire)
        DialogueInteractionObject dio = lastInteractedDialogue.interracted;

        string[] dialogues = localizationManager.GetDialogue(dio.text);
        float timeBetweenTextChange = dio.dialogue != null ? dio.dialogue.length/dialogues.Length : defaultDialogueSwitchTime;

        dialogueGameObject.SetActive(true);

        if(dio.dialogue != null)
        {
            dialogueAudioSource.clip = dio.dialogue;
            dialogueAudioSource.Play();
        }

        PlayDialogueTextCoroutine = StartCoroutine(PlayDialogueText(timeBetweenTextChange, dialogues));

    }

    private IEnumerator  PlayDialogueText(float timeBetweenTextChange, string[] text){
        foreach (string str in text)
        {
            dialogueUIText.text = str;
            yield return new WaitForSeconds(timeBetweenTextChange);
        }
        dialogueUIText.text = "";
        dialogueGameObject.SetActive(false);

        //We allow the coroutine to play again
        PlayDialogueTextCoroutine = null;
    }
}
