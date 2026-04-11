using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTwoExitDoor : MonoBehaviour
{
    private bool isOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

                SceneManager.LoadScene("RoomThree");
            }
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
        //play animation of door opening maybe
    }
}
