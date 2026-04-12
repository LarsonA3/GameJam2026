using UnityEngine;

public class R4VOicelines : MonoBehaviour
{
    public GameObject robots;

    private bool Played = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (!Played)
            {
                Played = true;
                this.GetComponent<AudioSource>().Play();
                robots.SetActive(true);
            }

        }

        

    }
}
