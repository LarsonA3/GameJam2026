using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorCheck : MonoBehaviour
{
    public static DoorCheck instance;

    public Image blackscreen;

    private bool isGuyDead = false;
    public AudioSource betrayAudio;

    private bool done = false;
    public GameObject player;

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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (other.CompareTag("Player") && !isGuyDead)
        {
            Debug.Log("player entered door when guy is not dead");
            //play betrayal audio   
            if (!done) { StartCoroutine(PlayBetrayalAudio()); }
            done = true;
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

            player.transform.rotation = Quaternion.Euler(x, y, z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = originalRotation;
        blackscreen.gameObject.SetActive(true);

        betrayAudio.Play();
        yield return new WaitForSeconds(betrayAudio.clip.length + 0.5f);
        PlayerDeath.instance.Die();
    }
}
