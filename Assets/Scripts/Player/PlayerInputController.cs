using Afterimage.Player;
using UnityEngine;

namespace Afterimage.Gameplay
{
    public class PrototypeBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private Transform startPoint;

        private void Start()
        {
            if (playerController == null)
            {
                playerController = FindObjectOfType<PlayerController>();
            }

            if (startPoint != null && playerController != null)
            {
                playerController.transform.position = startPoint.position;
            }

            GameStateManager.Instance?.SetState(GameStateType.StartingRun);
        }
    }
}
