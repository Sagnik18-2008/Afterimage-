using System.Collections.Generic;
using UnityEngine;

namespace Afterimage.Afterimage
{
    public class AfterimagePlayback : MonoBehaviour
    {
        private List<RecordedFrame> recordedFrames = new();
        private int currentIndex;
        private float startTime;
        private bool isPlaying;

        public bool IsPlaying => isPlaying;

        public void SetPlaybackData(IReadOnlyList<RecordedFrame> frames)
        {
            recordedFrames = new List<RecordedFrame>(frames);
            currentIndex = 0;
            startTime = Time.time;
            isPlaying = recordedFrames.Count > 0;
        }

        private void Update()
        {
            if (!isPlaying || recordedFrames.Count == 0)
            {
                return;
            }

            float elapsed = Time.time - startTime;

            while (currentIndex < recordedFrames.Count - 1 && recordedFrames[currentIndex + 1].Time <= elapsed)
            {
                currentIndex++;
            }

            RecordedFrame currentFrame = recordedFrames[currentIndex];
            transform.position = currentFrame.Position;
            transform.rotation = currentFrame.Rotation;

            if (currentIndex >= recordedFrames.Count - 1)
            {
                isPlaying = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IAfterimageInteractable interactable))
            {
                interactable.OnAfterimageTriggered(this);
            }
        }
    }
}
