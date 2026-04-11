using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{

    private AudioSource hoverSound;
    private AudioSource pressedSound;
    private Image img;

    void Start()
    {
        hoverSound = GetComponent<AudioSource>();
        pressedSound = this.transform.Find("Text (TMP)").GetComponent<AudioSource>();
        img = gameObject.GetComponent<Image>();
    }



    public void OnClick()
    {
        //sound plays button
        print("menu button clicked");
        pressedSound.Play();
        StartCoroutine(PlaySequence());
    }


    private IEnumerator PlaySequence()
    {
        print("menu seq started");
        //screen fade to black
        //play voicelines and overlay text
        yield return new WaitForSeconds(1f);

        //bright flash of light and load scene
        SceneManager.LoadScene("TitleScreen");
    }
}
