using UnityEngine;

public class GarbageChute : MonoBehaviour
{
    private bool guyLogged = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Torso" || other.gameObject.name == "Legs")
        {
            if (!guyLogged)
            {
                print("guy fell into garbage chute");
                DoorCheck.instance.SetGuyDead();
                guyLogged = true;
            }
        }

        if (other.CompareTag("Player"))
        {
            print("player fell in");
            PlayerDeath.instance.Die();
        }
    }
}