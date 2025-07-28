using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineCinematic : MonoBehaviour, ICinematic
{

    [SerializeField]
    private PlayableDirector playable;
    public void Pause()
    {
        playable.Pause();
    }

    public IEnumerator Play()
    {
        playable.Play();
        yield return new WaitUntil(() => playable.state != PlayState.Playing);
    }

    public void Skip()
    {
        playable.Stop();
    }
}
