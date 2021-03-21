using UnityEngine;
using UnityEngine.Playables;

public class CinematicsController : MonoBehaviour
{
    private PlayableDirector[] childrenCinematics;

    private void Awake()
    {
        childrenCinematics = GetComponentsInChildren<PlayableDirector>();

        foreach(PlayableDirector playDir in childrenCinematics)
        {
            playDir.gameObject.SetActive(false);
            playDir.played += PlayerController.DisableInput;
            playDir.stopped += PlayerController.EnableInput;
            playDir.played += CameraController.DisableInput;
            playDir.stopped += CameraController.EnableInput;
            playDir.gameObject.SetActive(true);
        }
    }
}
