using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClick() {
        StartCoroutine(PlaySequence());
    }


    private IEnumerator PlaySequence()
    {
        //screen fade to black
        //play voicelines and overlay text
        yield return new WaitForSeconds(10f);

        //bright flash of light and load scene
        SceneManager.LoadScene("RoomOne");
    }
}
