using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneChanger : MonoBehaviour
{
    // Function to load a scene by its name
    public void LoadByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Only trigger if the player enters
        {
            SceneManager.LoadScene("RoomFour");
        }
    }
}