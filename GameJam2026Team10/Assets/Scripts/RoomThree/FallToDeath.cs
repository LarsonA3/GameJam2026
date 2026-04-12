using UnityEngine;

public class FallToDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider thing)
    {
        if (thing.CompareTag("Player"))
        {
            print("player fell in");
            PlayerDeath.instance.Die();
        }
    }
}
