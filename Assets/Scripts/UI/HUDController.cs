using UnityEngine;
using UnityEngine.SceneManagement;

namespace Afterimage.UI
{
    public class TutorialController : MonoBehaviour
    {
        [SerializeField] private string[] steps =
        {
            "Swim forward using the touch drag.",
            "Swipe up or down to change depth.",
            "Tap to trigger a boost.",
            "Dodge around obstacles to avoid impact.",
            "Record your movement to create an Afterimage.",
            "Replay the Afterimage to trigger mechanisms."
        };

        [SerializeField] private int stepIndex;

        public void AdvanceTutorial()
        {
            if (stepIndex < steps.Length - 1)
            {
                stepIndex++;
            }
        }

        public void FinishTutorial()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
