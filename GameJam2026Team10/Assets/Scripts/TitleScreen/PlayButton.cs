using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private AudioSource hoverSound;
    private AudioSource pressedSound;
    private Image img;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hoverSound = GetComponent<AudioSource>();
        pressedSound = this.transform.Find("Text (TMP)").GetComponent<AudioSource>();
        img = gameObject.GetComponent<Image>();
    }



    public void OnClick() {
        //sound plays button
        print("play button clicked");
        pressedSound.Play();
        StartCoroutine(PlaySequence());
    }


    private IEnumerator PlaySequence()
    {
        print("play seq started");
        //screen fade to black
        //play voicelines and overlay text
        yield return new WaitForSeconds(1f);

        //bright flash of light and load scene
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("RoomOne");
    }
}
