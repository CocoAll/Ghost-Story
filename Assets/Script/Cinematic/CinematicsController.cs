using UnityEngine;
using UnityEngine.Playables;

public class CinematicsController : MonoBehaviour
{
    private PlayableDirector[] childrenCinematics;
    [SerializeField]
    private BooleanValue inputsEnabled;

    private void Awake()
    {
        childrenCinematics = GetComponentsInChildren<PlayableDirector>();

        foreach(PlayableDirector playDir in childrenCinematics)
        {
            playDir.gameObject.SetActive(false);
            playDir.played += _ => inputsEnabled.value = false;
            playDir.stopped += _ => inputsEnabled.value = true;
            playDir.gameObject.SetActive(true);
        }
    }
}
