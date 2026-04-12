using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomFourExitDoor : MonoBehaviour
{
    private bool isOpen = false;

    public GameObject robots;

    public GameObject redRef;
    public GameObject greenRef;

    public Material greenMatPrefab;
    public Material blackMatPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpen && robots != null && robots.transform.childCount == 0)
        {
            OpenDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isOpen) { 
            if (other.CompareTag("Player"))
            {
                print("player entered exit door trigger");
                //play sound effect
                //play animation of door opening
                //load next scene

                SceneManager.LoadScene("FinalRoom");
            }
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
        //play animation of door opening maybe
        // switch greenRef material to greenMatPrefab
        //switch redRef material to blackMatPrefab
        greenRef.GetComponent<Renderer>().material = greenMatPrefab;
        redRef.GetComponent<Renderer>().material = blackMatPrefab;
        //turn off light of redRef
        //turn on light of greenref
        greenRef.transform.Find("l").GetComponent<Light>().enabled = true;
        redRef.transform.Find("l").GetComponent<Light>().enabled = false;
        greenRef.GetComponent<AudioSource>().Play();

    }
}
