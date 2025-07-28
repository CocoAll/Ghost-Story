using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    public static CinematicManager Instance { get; private set; }

    private Queue<ICinematic> cinematicQueue = new Queue<ICinematic>();
    [SerializeField]
    private bool isPlaying = false;

    private float count = 0.0f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        Debug.Log("Update count : " + cinematicQueue.Count);
        count += Time.deltaTime;
        if(count >= 0.2f)
        {
            count = 0.0f;
           
            if(cinematicQueue.Count > 0)
            {
                TryPlayNext();
            }
        }
    }

    public void PlayCinematic(ICinematic cinematic)
    {
        cinematicQueue.Enqueue(cinematic);
        TryPlayNext();
    }

    private void TryPlayNext()
    {
        Debug.Log("TryPlayNext count : " + cinematicQueue.Count);
        if (isPlaying || cinematicQueue.Count == 0) return;

        isPlaying = true;
        ICinematic next = cinematicQueue.Dequeue();
        StartCoroutine(RunCinematic(next));
    }

    private IEnumerator RunCinematic(ICinematic cinematic)
    {
        yield return cinematic.Play();
        isPlaying = false;
        TryPlayNext();
    }
}
