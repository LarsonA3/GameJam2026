using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCheck : MonoBehaviour
{
    public static DoorCheck instance;

    private bool isGuyDead = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SetGuyDead()
    {
        isGuyDead = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isGuyDead)
        {
            Debug.Log("Player entered door when guy is dead");
            SceneManager.LoadScene("YouWin");
        }
        else if (other.CompareTag("Player") && !isGuyDead)
        {
            Debug.Log("player entered door when guy is not dead");
            PlayerDeath.instance.Die();
        }
    }
}
