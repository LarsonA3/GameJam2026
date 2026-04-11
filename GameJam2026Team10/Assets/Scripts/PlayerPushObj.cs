using UnityEngine;

public class PlayerPushObj : MonoBehaviour
{
    public float pushPower = 2f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!hit.gameObject.CompareTag("PushableObject")) return;
        Rigidbody rigid = hit.collider.attachedRigidbody;
        if (rigid == null || rigid.isKinematic) return;
        if (hit.moveDirection.y < -0.3f) return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        rigid.linearVelocity = pushDir * pushPower;
    }
}
