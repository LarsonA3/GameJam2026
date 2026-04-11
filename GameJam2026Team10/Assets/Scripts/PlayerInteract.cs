using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 2.5f;

    public Sprite eDefault;
    public Sprite ePressed;

    private Camera mainCamera;
    private Image currentPromptImage;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, interactDistance, ~0, QueryTriggerInteraction.Collide);

            float closestDist = Mathf.Infinity;
            IInteractable closest = null;
            GameObject closestObj = null;

            foreach (Collider col in hits)
            {
                IInteractable interactable = col.GetComponent<IInteractable>();
                if (interactable == null) continue;

                float dist = Vector3.Distance(transform.position, col.transform.position);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = interactable;
                    closestObj = col.gameObject;
                }
            }

            if (closest != null)
            {
                closest.Interact();

                // Find the Image in the interactable's canvas
                Transform canvas = closestObj.transform.Find("InteractCanvas");
                if (canvas != null)
                    currentPromptImage = canvas.Find("InteractE")?.GetComponent<Image>();

                if (currentPromptImage != null)
                {
                    currentPromptImage.sprite = ePressed;
                    CancelInvoke(nameof(RevertSprite));
                    Invoke(nameof(RevertSprite), 0.15f);
                }
            }
        }
    }

    void RevertSprite()
    {
        if (currentPromptImage != null)
            currentPromptImage.sprite = eDefault;
    }
}