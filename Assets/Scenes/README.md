using UnityEngine;

namespace Afterimage.Environment
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private int difficultyRating = 1;
        [SerializeField] private bool blocksProgress = true;
        [SerializeField] private float damageAmount = 1f;

        public int DifficultyRating => difficultyRating;
        public bool BlocksProgress => blocksProgress;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player hit obstacle. Difficulty: " + difficultyRating);
            }
        }
    }
}
