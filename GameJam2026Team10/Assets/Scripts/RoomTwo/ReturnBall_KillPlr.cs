using UnityEngine;

public class ReturnBall_KillPlr : MonoBehaviour
{
    public float throwForce = 15f;

    private Transform ballSpawnSpot;
    private Transform throwBallSpot;

    private void Start()
    {
        ballSpawnSpot = transform.Find("BallSpawnSpot");
        throwBallSpot = transform.Find("ThrowBallSpot");

    }

    private void OnTriggerEnter(Collider thing)
    {
        if (thing.CompareTag("Player"))
        {
            print("player fell in");
            PlayerDeath.instance.Die();
        }
        else if (thing.gameObject.CompareTag("PushableObject"))
        {
            Rigidbody rb = thing.gameObject.GetComponent<Rigidbody>();

            if (rb != null && ballSpawnSpot != null && throwBallSpot != null)
            {
                // calculate dir
                Vector3 throwDirection = (throwBallSpot.position - ballSpawnSpot.position).normalized;

                Vector3 catchPos = new Vector3(thing.transform.position.x, ballSpawnSpot.position.y, ballSpawnSpot.position.z);
                //move ball to correct spot
                rb.position = catchPos;


                // zero velocity
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // throw that shi
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
            }
        }
    }
}