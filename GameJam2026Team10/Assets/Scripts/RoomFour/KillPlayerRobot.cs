using UnityEngine;

public class KillPlayerRobot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PlayerDeath.instance.Die();

        if (other.CompareTag("Robot"))
            Destroy(other.gameObject);
    }
}