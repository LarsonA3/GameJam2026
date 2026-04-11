using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace StarterAssets
{
    public class PlayerTelepathy : MonoBehaviour
    {
        [Header("Grab Settings")]
        public float grabRange = 5f;
        public float moveSpeed = 15f;
        public float throwForce = 10f;
        public float throwGravityDelay = 0.2f;

        [Header("Stamina")]
        public float maxStamina = 100f;
        public float drainRate = 15f;
        public float rechargeRate = 8f;
        public Slider staminaSlider;

        private float stamina;
        private bool exhausted;

        private Rigidbody heldObject;
        private float grabHoldDistance;
        private bool wasGravity;
        private Rigidbody thrownObject;
        private float gravityTimer;

        private Camera cam;
        private InputSystem_Actions input;
        private PlayerInput playerInput;

        private void Awake()
        {
            input = new InputSystem_Actions();
            input.Enable();
            playerInput = GetComponent<PlayerInput>();
        }

        private void Start()
        {
            cam = Camera.main;
            stamina = maxStamina;
            staminaSlider.maxValue = maxStamina;
        }

        private void Update()
        {
            UpdateStamina();

            if (gravityTimer > 0f)
            {
                gravityTimer -= Time.deltaTime;
                if (gravityTimer <= 0f && thrownObject != null)
                {
                    thrownObject.useGravity = true;
                    thrownObject = null;
                }
            }

            if (GetRMB() && heldObject != null)
            {
                ThrowObject();
                return;
            }

            if (GetLMB())
            {
                if (heldObject == null && stamina > 0f && !exhausted)
                    TryGrab();
            }
            else
            {
                if (heldObject != null)
                    DropObject();
            }
        }

        private void UpdateStamina()
        {
            if (heldObject != null)
            {
                stamina -= drainRate * Time.deltaTime;
                if (stamina <= 0f)
                {
                    stamina = 0f;
                    exhausted = true;
                    DropObject();
                }
            }
            else
            {
                stamina = Mathf.Min(stamina + rechargeRate * Time.deltaTime, maxStamina);
                if (exhausted && stamina >= maxStamina * 0.25f)
                    exhausted = false;
            }

            if (staminaSlider != null)
                staminaSlider.value = stamina;
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

                if (rb == thrownObject)
                {
                    gravityTimer = 0f;
                    thrownObject = null;
                }

                heldObject       = rb;
                grabHoldDistance = Vector3.Distance(cam.transform.position, rb.position);
                wasGravity       = true;

                rb.useGravity = false;
                playerInput.actions["Jump"].Disable();
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
            playerInput.actions["Jump"].Enable();
        }

        private void ThrowObject()
        {
            thrownObject = heldObject;
            heldObject = null;
            playerInput.actions["Jump"].Enable();

            thrownObject.linearVelocity = cam.transform.forward * throwForce;
            gravityTimer = throwGravityDelay;
        }

        private bool GetLMB()
        {
            return input.Player.Attack.IsPressed();
        }

        private bool GetRMB()
        {
            return input.Player.Throw.IsPressed();
        }
    }
}
