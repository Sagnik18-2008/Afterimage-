using UnityEngine;

namespace Afterimage.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float normalSpeed = 8f;
        [SerializeField] private float boostSpeed = 14f;
        [SerializeField] private float acceleration = 6f;
        [SerializeField] private float rotationSpeed = 8f;
        [SerializeField] private float verticalMoveSpeed = 4f;
        [SerializeField] private float boostDuration = 1.2f;

        private CharacterController controller;
        private Vector3 moveInput;
        private float depthTarget;
        private float boostTimer;
        private Vector3 velocity;

        public float CurrentSpeed => boostTimer > 0f ? boostSpeed : normalSpeed;
        public bool IsBoosting => boostTimer > 0f;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            if (controller == null)
            {
                controller = gameObject.AddComponent<CharacterController>();
            }

            controller.enableOverlapRecovery = true;
            controller.height = 1.8f;
            controller.radius = 0.3f;
            controller.center = new Vector3(0f, 0.9f, 0f);
        }

        private void Update()
        {
            if (boostTimer > 0f)
            {
                boostTimer -= Time.deltaTime;
            }

            Vector3 inputDirection = Vector3.zero;
            if (moveInput.sqrMagnitude > 0.01f)
            {
                inputDirection = transform.forward * moveInput.z + transform.right * moveInput.x;
                inputDirection = Vector3.ClampMagnitude(inputDirection, 1f);
            }

            float targetX = Mathf.Lerp(velocity.x, inputDirection.x * CurrentSpeed, Time.deltaTime * acceleration);
            float targetZ = Mathf.Lerp(velocity.z, inputDirection.z * CurrentSpeed, Time.deltaTime * acceleration);
            float targetY = Mathf.Lerp(velocity.y, depthTarget * verticalMoveSpeed, Time.deltaTime * acceleration);

            velocity = new Vector3(targetX, targetY, targetZ);
            controller.Move(velocity * Time.deltaTime);

            if (moveInput.sqrMagnitude > 0.01f)
            {
                float yaw = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg;
                Quaternion desiredRotation = Quaternion.Euler(0f, yaw, 0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
            }
        }

        public void SetMoveInput(Vector2 input)
        {
            moveInput = new Vector3(input.x, 0f, input.y);
        }

        public void SetDepthInput(float value)
        {
            depthTarget = Mathf.Clamp(value, -1f, 1f);
        }

        public void TriggerBoost()
        {
            if (boostTimer <= 0f)
            {
                boostTimer = boostDuration;
            }
        }
    }
}
