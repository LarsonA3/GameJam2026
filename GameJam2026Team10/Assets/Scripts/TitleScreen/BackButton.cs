using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackButton : MonoBehaviour
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
        StartCoroutine(OpenControlsMenu());
    }

    private IEnumerator OpenControlsMenu()
    {
        // show controls text and buttons

        yield return new WaitForSeconds(0.5f);

        
        transform.parent.parent.Find("MainMenu").gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);



    }
}
