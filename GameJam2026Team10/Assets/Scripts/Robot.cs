using UnityEngine;

public class Robot : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;

    [Header("Shooting")]
    public GameObject laserPrefab;
    public Transform firePoint;
    public float fireRate = 3f;

    private float fireTimer;
    private Transform player;

    private void Start()
    {
        fireTimer = fireRate;
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) player = p.transform;
    }

    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0f)
        {
            fireTimer = fireRate;
            if (laserPrefab != null && firePoint != null)
            {
                Quaternion shotRotation = firePoint.rotation;
                if (player != null)
                {
                    Vector3 dir = (player.position - firePoint.position).normalized;
                    shotRotation = Quaternion.LookRotation(dir);
                }
                Instantiate(laserPrefab, firePoint.position, shotRotation);
            }
        }
    }
}
