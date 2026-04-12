using UnityEngine;

public class ComputerInteractable : MonoBehaviour, IInteractable
{
    public FileExplorerUI fileExplorerUI;

    public void Interact()
    {
        if (fileExplorerUI != null)
            fileExplorerUI.Open();
    }
}
