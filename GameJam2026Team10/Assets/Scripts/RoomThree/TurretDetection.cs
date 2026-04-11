using UnityEngine;

public class TurretDetection : MonoBehaviour
{
    public float DetectionRange = 30;
    public float DetectionAngle = 12;

    bool isInAngle, isNotHidden;

    public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isInAngle = false;
        isNotHidden = false;

        //hidden
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (Player.transform.position - transform.position), out hit, Mathf.Infinity))
        {
            isNotHidden = true;
        }

        //angle
        Vector3 toPlayer = Player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, toPlayer);
        float distance = toPlayer.magnitude;

        if (angle < DetectionAngle && distance < DetectionRange)
        {
            isInAngle = true;
        }

        if (isInAngle && isNotHidden)
        {
            
        }

    }
}
