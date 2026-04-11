using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 20f;
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponentInParent<Health>();
        if (health != null)
            health.TakeDamage(damage);

        Destroy(gameObject);
    }
}
