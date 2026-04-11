using UnityEngine;

public class GuyOnHit : MonoBehaviour
{
    public GameObject head;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PushableObject"))
        {
            print("player killed guy with block");
            Destroy(head);
        }
    }
}