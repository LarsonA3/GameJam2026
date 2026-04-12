using UnityEngine;

public class ResetButton : MonoBehaviour, IInteractable
{
    public TargetHandler targetHandler;

    public string GetPromptText()
    {
        return "Press button";
    }

    public void Interact()
    {
        Debug.Log("ResetButton Interact called");

        if (targetHandler != null)
        {
            targetHandler.ResetAll();
        }
    }
}