using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomOneExitDoor : MonoBehaviour
{
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
        if (other.CompareTag("Player"))
        {
            print("player entered exit door trigger");
            //play sound effect
            //play animation of door opening
            //load next scene
            InputSystem_Actions inputActions = new InputSystem_Actions();
            inputActions.Disable();  
            SceneManager.LoadScene("RoomTwo");
        }

    }
}
