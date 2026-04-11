using UnityEngine;

public class GuyOnHit : MonoBehaviour
{
    private GameObject head;

    private void Start()
    {
        head = transform.Find("Head").gameObject;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PushableObject"))
        {
            print("player killed guy with block");
            DoorCheck.instance.SetGuyDead();
            head.SetActive(false);
        }
    }
}