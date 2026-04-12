using UnityEngine;

namespace StarterAssets
{
    public class FootstepManager : MonoBehaviour
    {
        public float stepDelay = 0.5f;

        private float stepTimer;

        private InputSystem_Actions input;

        private void Awake()
        {
            input = new InputSystem_Actions();
            input.Enable();
        }

        private void Update()
        {
            Vector2 moveInput = input.Player.Move.ReadValue<Vector2>();

            if (moveInput.magnitude > 0.1f)
            {
                stepTimer -= Time.deltaTime;

                if (stepTimer <= 0f)
                {
                    SoundManager.Play(SoundType.Footsteps, null, -1, 0.5f);
                    stepTimer = stepDelay;
                }
            }
            else
            {
                stepTimer = 0f;
            }
        }
    }
}