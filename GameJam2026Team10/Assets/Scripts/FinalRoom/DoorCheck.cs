using UnityEngine;

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
}
