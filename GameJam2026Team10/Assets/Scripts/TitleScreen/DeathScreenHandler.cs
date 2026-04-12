using UnityEngine;
using System.Collections;

public class DeathScreenHandler : MonoBehaviour
{
    public GameObject endScreenCanvas;

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

        AudioSource screenAudio = endScreenCanvas.GetComponent<AudioSource>();
        if (screenAudio != null)
        {
            screenAudio.Play();
        }
    }
}