using UnityEngine;

namespace Afterimage.Player
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;

        private Vector2 dragOrigin;
        private bool dragging;

        private void Update()
        {
            if (playerController == null)
            {
                return;
            }

            Vector2 moveInput = Vector2.zero;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    dragOrigin = touch.position;
                    dragging = true;
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    if (dragging)
                    {
                        Vector2 delta = touch.position - dragOrigin;
                        moveInput = new Vector2(delta.x, delta.y).normalized * 1.5f;
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    dragging = false;
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                dragging = true;
            }
            else if (Input.GetMouseButton(0) && dragging)
            {
                Vector2 delta = (Vector2)Input.mousePosition - dragOrigin;
                moveInput = new Vector2(delta.x, delta.y).normalized * 1.5f;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                dragging = false;
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.01f)
            {
                moveInput.y += Input.GetAxisRaw("Vertical");
            }

            playerController.SetMoveInput(moveInput);

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                playerController.SetDepthInput(1f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                playerController.SetDepthInput(-1f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerController.TriggerBoost();
            }
        }
    }
}
