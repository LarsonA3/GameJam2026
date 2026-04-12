using System.Collections;
using UnityEngine;

public class ShowerSequenceHandler : MonoBehaviour
{
    public AudioSource showerAudio;
    public AudioSource voiceLineAudio;

    public float showerDuration = 2f;

    private bool hasPlayed = false;

    public void StartSequence()
    {
        if (!hasPlayed)
        {
            hasPlayed = true;
            StartCoroutine(Sequence());
        }
    }

    private IEnumerator Sequence()
    {
        SoundManager.Play(SoundType.ButtonPress);

        if (showerAudio != null)
        {
            showerAudio.Play();
        }

        yield return new WaitForSeconds(showerDuration);

        if (showerAudio != null)
        {
            showerAudio.Stop();
        }

        if (voiceLineAudio != null)
        {
            voiceLineAudio.Play();
        }
    }
}