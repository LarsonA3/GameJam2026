using UnityEngine;

public class TurretDetection : MonoBehaviour
{
    public float DetectionRange = 30;
    public float DetectionAngle = 45;
    public float DamageAmount = 25f;
    public float DamageCooldown = 1f;

    bool isInAngle, isNotHidden;

    public GameObject Player;

    float damageTimer = 0f;

    void Start()
    {

    }

    void Update()
    {
        isInAngle = false;
        isNotHidden = false;

        if (Player == null)
        {
            return;
        }

        Vector3 toPlayer = Player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, toPlayer);
        float distance = toPlayer.magnitude;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, toPlayer.normalized, out hit, distance))
        {
            if (hit.transform.IsChildOf(Player.transform))
            {
                isNotHidden = true;
            }
        }

        if (angle < DetectionAngle && distance < DetectionRange)
        {
            isInAngle = true;
        }

        damageTimer -= Time.deltaTime;

        if (isInAngle && isNotHidden)
        {
            if (damageTimer <= 0f)
            {
                SoundManager.Play(SoundType.LaserShot);
                Health playerHealth = Player.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(DamageAmount);
                }

                damageTimer = DamageCooldown;
            }
        }
    }
}