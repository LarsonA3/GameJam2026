using UnityEngine;
using UnityEngine.InputSystem;

public class DoorDebug : MonoBehaviour
{
    Rigidbody rb;

    void Start() => rb = GetComponent<Rigidbody>();

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(Vector3.right * 5f, ForceMode.Impulse);
            Debug.Log("Force applied");
        }
    }
}