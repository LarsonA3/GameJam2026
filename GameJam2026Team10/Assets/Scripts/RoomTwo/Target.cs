using UnityEngine;

public class Target : MonoBehaviour
{
    private TargetHandler parentHandler;
    private int myNumber;

    public float cooldown = 0.5f;
    private float lastTriggerTime;

    void Start()
    {
        parentHandler = GetComponentInParent<TargetHandler>();
        //check for number
        if (transform.childCount > 0)
        {
            string childName = transform.GetChild(0).name;
            if (int.TryParse(childName, out int result))
            {
                myNumber = result;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PushableObject"))
        {
            if (Time.time > lastTriggerTime + cooldown)
            {
                if (parentHandler != null)
                {
                    parentHandler.Enter(myNumber);
                    lastTriggerTime = Time.time;
                }
            }
        }
    }
}