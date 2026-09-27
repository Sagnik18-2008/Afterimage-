using System;
using UnityEngine;

namespace Afterimage.Mystery
{
    public class MysteryEventManager : MonoBehaviour
    {
        public event Action<string> StoryBeatTriggered;

        [SerializeField] private bool abnormalAfterimageUnlocked;
        [SerializeField] private float abnormalChance = 0.15f;

        public bool AbnormalAfterimageUnlocked => abnormalAfterimageUnlocked;

        public void TriggerStoryBeat(string message)
        {
            StoryBeatTriggered?.Invoke(message);
            Debug.Log(message);
        }

        public void EvaluateAfterimageState(float currentDepth, float recordedDepth)
        {
            if (!abnormalAfterimageUnlocked && UnityEngine.Random.value < abnormalChance)
            {
                abnormalAfterimageUnlocked = true;
                TriggerStoryBeat("An abnormal Afterimage is beginning to remember the abyss.");
            }

            if (Mathf.Abs(currentDepth - recordedDepth) > 4f)
            {
                TriggerStoryBeat("The Afterimage no longer matches the recorded path.");
            }
        }
    }
}
