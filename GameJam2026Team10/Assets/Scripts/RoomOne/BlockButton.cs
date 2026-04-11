using UnityEngine;

public class BlockButton : MonoBehaviour, IInteractable
{
    public GameObject CubePrefab;
    public float cooldown = 2f;

    private float nextInteractTime = 0f;

    public void Interact()
    {
        if (Time.time < nextInteractTime) return;

        nextInteractTime = Time.time + cooldown;

        this.GetComponent<AudioSource>()?.Play();

        print("player interacted w button");
        Instantiate(CubePrefab, transform.Find("SpawnLocation").transform.position, Quaternion.identity);
    }
}