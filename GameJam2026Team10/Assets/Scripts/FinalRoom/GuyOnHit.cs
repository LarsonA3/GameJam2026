using UnityEngine;

public class GuyOnHit : MonoBehaviour
{
    private GameObject head;
    public AudioSource hitSound;
    public AudioSource crunchSound;

    private void Start()
    {
        head = transform.Find("Head").gameObject;
        if (hitSound != null) hitSound.Stop();
        if (crunchSound != null) crunchSound.Stop();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PushableObject"))
        {
            print("player killed guy with block");
            DoorCheck.instance.SetGuyDead();
            head.SetActive(false);
            hitSound.Play();
            if (crunchSound != null) crunchSound.Play();
        }
    }
}