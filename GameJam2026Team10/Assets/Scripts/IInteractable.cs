public interface IInteractable
{
    /// /////////////// OTHER SCRIPTS MUST INHERIT FROM THIS AND OVERRIDE INTERACT() TO DEFINE WHAT HAPPENS WHEN THE PLAYER INTERACTS WITH THE OBJECT ///////////////
    // This method will be called when the player interacts with the object
    void Interact();
}
