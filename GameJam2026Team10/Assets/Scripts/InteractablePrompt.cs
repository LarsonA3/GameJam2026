using UnityEngine;

public class InteractablePrompt : MonoBehaviour
{
    public float showDistance = 3f;
    private GameObject promptCanvas;
    private Transform player;

    void Start()
    {
        promptCanvas = transform.Find("InteractCanvas")?.gameObject;

        if (promptCanvas == null)
            Debug.LogError($"{gameObject.name}: InteractCanvas NOT found.");
        else
            Debug.Log($"{gameObject.name}: InteractCanvas found OK. Setting inactive.");

        promptCanvas?.SetActive(false);

        GameObject p = GameObject.Find("PlayerCapsule");
        if (p != null)
        {
            player = p.transform;
            Debug.Log($"Player found: {p.name}");
        }
        else
            Debug.LogError("Player NOT found — is the Player tag set?");
    }

    void Update()
    {
        if (promptCanvas == null || player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);
        //Debug.Log($"dist to player: {dist}");
        promptCanvas.SetActive(dist <= showDistance);
    }
}