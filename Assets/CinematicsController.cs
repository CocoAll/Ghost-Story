using UnityEngine;
using UnityEngine.Playables;

public class CinematicsController : MonoBehaviour
{
    [SerializeField]
    PlayableDirector[] childrenCinematics;
    //TODO : A refaire ! C'est moche
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
