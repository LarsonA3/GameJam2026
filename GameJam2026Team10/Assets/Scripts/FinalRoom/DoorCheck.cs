using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCheck : MonoBehaviour
{
    public static DoorCheck instance;

    private bool isGuyDead = false;
    public AudioSource betrayAudio;

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
            //play betrayal audio   
            StartCoroutine(PlayBetrayalAudio());
        }
    }


    private IEnumerator PlayBetrayalAudio()
    {
        AudioSource zapSource = GetComponent<AudioSource>();
        zapSource.Play();

        float zapDuration = zapSource.clip.length;
        float elapsed = 0f;

        //to snap back to
        Quaternion originalRotation = transform.rotation;

        while (elapsed < zapDuration)
        {
            // random rotation
            float x = Random.Range(-45f, 45f);
            float y = Random.Range(0f, 360f);
            float z = Random.Range(-45f, 45f);

            transform.rotation = Quaternion.Euler(x, y, z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = originalRotation;

        betrayAudio.Play();
        yield return new WaitForSeconds(betrayAudio.clip.length + 3f);
        PlayerDeath.instance.Die();
    }
}
