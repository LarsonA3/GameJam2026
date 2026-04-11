using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public static PlayerDeath instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    public void Die()
    {
        //do stuff
        print("player death called");
        SceneManager.LoadScene("RoomOne");
    }
}
