using UnityEngine;

public class QuitButton : MonoBehaviour
{
    private AudioSource hoverSound;
    private AudioSource pressedSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hoverSound = GetComponent<AudioSource>();
        pressedSound = this.transform.Find("Text (TMP)").GetComponent<AudioSource>();
    }



    public void OnClick()
    {
        
        //sound plays button
        pressedSound.Play();
        print("quitting game...");
        Application.Quit();
        print("quitting game...");
    }
}
