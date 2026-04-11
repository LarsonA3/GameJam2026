using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class PlayerTelepathy : MonoBehaviour
    {
        [Header("Grab Settings")]
        public float grabRange = 5f;
        public float moveSpeed = 15f;

        private Rigidbody heldObject;
        private float grabHoldDistance;
        private bool wasGravity;

        private Camera cam;
        private InputSystem_Actions input;

        private void Awake()
        {
            input = new InputSystem_Actions();
            input.Enable();
        }

        private void Start()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            if (GetLMB())
            {
                if (heldObject == null)
                    TryGrab();
            }
            else
            {
                if (heldObject != null)
                    DropObject();
            }
        }

        private void FixedUpdate()
        {
            if (heldObject != null)
                MoveHeldObject();
        }

        private void TryGrab()
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out RaycastHit hit, grabRange))
            {
                if (!hit.collider.CompareTag("PushableObject")) return;

                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb == null) return;

                heldObject       = rb;
                grabHoldDistance = Vector3.Distance(cam.transform.position, rb.position);
                wasGravity       = rb.useGravity;

                rb.useGravity = false;
            }
        }

        private void MoveHeldObject()
        {
            Vector3 targetPos = cam.transform.position + cam.transform.forward * grabHoldDistance;
            Vector3 direction = targetPos - heldObject.position;
            heldObject.linearVelocity  = direction * moveSpeed;
            heldObject.angularVelocity = Vector3.Lerp(heldObject.angularVelocity, Vector3.zero, Time.deltaTime * 10f);
        }

        private void DropObject()
        {
            heldObject.useGravity = wasGravity;
            heldObject = null;
        }

        private bool GetLMB()
        {
            return input.Player.Attack.IsPressed();
        }
    }
}
