using System.Collections;
using Tripolygon.UModelerX.Runtime;
using UnityEngine;

public class RoomOneVoicelineHandler : MonoBehaviour
{
    public GameObject food;

    private bool Played = false;

    public GameObject shower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        food.SetActive(false);
        StartCoroutine(PlayVoiceline());
        shower.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlayVoiceline()
    {
        yield return new WaitForSeconds(20.5f);
        //drop food
        food.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        food.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2f);

        this.transform.Find("Second").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(15f);
        shower.SetActive(true);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!Played)
            {
                Played=true;
                this.GetComponent<AudioSource>().Play();
            }
        }

    }
}
