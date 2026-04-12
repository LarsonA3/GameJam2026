using UnityEngine;

public class ShowerButton : MonoBehaviour, IInteractable
{
    public ShowerSequenceHandler sequenceHandler;

    public string GetPromptText()
    {
        return "Press button";
    }

    public void Interact()
    {
        Debug.Log("ShowerButton Interact called");

        if (sequenceHandler != null)
        {
            sequenceHandler.StartSequence();
        }
    }
}