using System.Collections;

public interface ICinematic
{
    IEnumerator Play();
    void Pause();
    void Skip();
}