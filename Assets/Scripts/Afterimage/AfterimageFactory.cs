using UnityEngine;
using UnityEngine.UI;

namespace Afterimage.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private Text distanceText;
        [SerializeField] private Text fragmentText;
        [SerializeField] private Text boostText;
        [SerializeField] private Image boostFill;

        private float currentDistance;

        private void Update()
        {
            if (distanceText != null)
            {
                distanceText.text = $"Distance: {currentDistance:0}m";
            }

            if (boostText != null)
            {
                boostText.text = "Boost";
            }

            if (boostFill != null)
            {
                boostFill.fillAmount = 0.5f;
            }
        }

        public void UpdateDistance(float distance)
        {
            currentDistance = distance;
        }

        public void UpdateFragmentCount(int count)
        {
            if (fragmentText != null)
            {
                fragmentText.text = $"Fragments: {count}";
            }
        }
    }
}
