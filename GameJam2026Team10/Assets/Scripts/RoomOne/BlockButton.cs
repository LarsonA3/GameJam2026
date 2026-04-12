using UnityEngine;

public class BlockButton : MonoBehaviour, IInteractable
{
    public GameObject CubePrefab;
    public float cooldown = 2f;

    private float nextInteractTime = 0f;

    public void Interact()
    {
        if (Time.time < nextInteractTime) return;
        SoundManager.Play(SoundType.ButtonPress);
        nextInteractTime = Time.time + cooldown;

        print("player interacted w button");
        Instantiate(CubePrefab, transform.Find("SpawnLocation").transform.position, Quaternion.identity);
    }
}