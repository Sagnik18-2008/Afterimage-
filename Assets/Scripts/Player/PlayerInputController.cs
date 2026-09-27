using UnityEngine;

namespace Afterimage.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float normalSpeed = 8f;
        [SerializeField] private float boostSpeed = 14f;
        [SerializeField] private float acceleration = 6f;
        [SerializeField] private float rotationSpeed = 90f;
        [SerializeField] private float verticalSpeed = 4f;
        [SerializeField] private float boostDuration = 1.5f;

        [Header("References")]
        [SerializeField] private Transform visualRoot;

        private Rigidbody rb;
        private Vector3 moveInput;
        private float depthInput;
        private float boostTimer;

        public float NormalSpeed => normalSpeed;
        public float CurrentSpeed { get; private set; }
        public float BoostDuration => boostDuration;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
            }

            rb.useGravity = false;
            rb.drag = 1f;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        private void Update()
        {
            if (boostTimer > 0f)
            {
                boostTimer -= Time.deltaTime;
            }

            Vector3 targetVelocity = (transform.forward * moveInput.z + transform.right * moveInput.x) * GetCurrentSpeed();
            targetVelocity.y = depthInput * verticalSpeed;

            Vector3 velocity = Vector3.Lerp(rb.velocity, targetVelocity, Time.deltaTime * acceleration);
            rb.velocity = velocity;

            if (moveInput != Vector3.zero)
            {
                Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(moveInput.x, 0f, moveInput.z), Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed * 0.01f);
            }

            if (visualRoot != null)
            {
                visualRoot.localPosition = Vector3.Lerp(visualRoot.localPosition, new Vector3(0f, depthInput * 0.6f, 0f), Time.deltaTime * 5f);
            }
        }

        public void SetMoveInput(Vector2 input)
        {
            moveInput = new Vector3(input.x, 0f, input.y);
        }

        public void SetDepthInput(float delta)
        {
            depthInput = Mathf.Clamp(depthInput + delta, -1f, 1f);
        }

        public void TriggerBoost()
        {
            if (boostTimer > 0f)
            {
                return;
            }

            boostTimer = boostDuration;
        }

        public float GetCurrentSpeed()
        {
            if (boostTimer > 0f)
            {
                CurrentSpeed = boostSpeed;
                return boostSpeed;
            }

            CurrentSpeed = normalSpeed;
            return normalSpeed;
        }
    }
}
