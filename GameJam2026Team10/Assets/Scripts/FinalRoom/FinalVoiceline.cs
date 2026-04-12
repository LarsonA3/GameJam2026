using UnityEngine;

public class FinalVoiceline : MonoBehaviour
{
    public AudioSource firstline;
    private bool Played = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (!Played)
            {
                Played = true;
                firstline.Play();
            }

        }



    }
}
