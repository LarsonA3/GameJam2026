using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheatsButton : MonoBehaviour
{
    private AudioSource hoverSound;
    private AudioSource pressedSound;
    public GameObject controlsmenu;

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

        
        controlsmenu.SetActive(true);
        print("Set controls active");
        transform.parent.gameObject.SetActive(false);
        print("Set main menu inactive");

        yield return new WaitForSeconds(0.5f);



    }
}
