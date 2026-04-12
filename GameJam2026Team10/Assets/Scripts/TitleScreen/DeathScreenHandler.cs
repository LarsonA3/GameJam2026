using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class DeathScreenHandler : MonoBehaviour
{
    public GameObject endScreenCanvas;
    public GameObject otherthing;
    void Start()
    {
        if (endScreenCanvas != null)
        {
            endScreenCanvas.SetActive(false);
            StartCoroutine(LoadDeath());
        }
        else
        {
            Debug.LogError("assign end screen");
        }
    }

    private IEnumerator LoadDeath()
    {
        yield return new WaitForSeconds(1.5f);

        endScreenCanvas.SetActive(true);
        otherthing.SetActive(false);

        AudioSource screenAudio = endScreenCanvas.GetComponent<AudioSource>();
        if (screenAudio != null)
        {
            screenAudio.Play();
        }
    }
}