using System.Collections.Generic;
using UnityEngine;

namespace Afterimage.Afterimage
{
    public class AfterimageManager : MonoBehaviour
    {
        [SerializeField] private AfterimageRecorder recorder;
        [SerializeField] private GameObject afterimagePrefab;
        [SerializeField] private Transform spawnPoint;

        private readonly List<AfterimagePlayback> spawnedAfterimages = new();

        public void CreateAfterimage()
        {
            if (recorder == null || recorder.RecordedFrames.Count == 0)
            {
                return;
            }

            if (afterimagePrefab == null)
            {
                Debug.LogWarning("Afterimage prefab is missing.");
                return;
            }

            Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;
            GameObject instance = Instantiate(afterimagePrefab, spawnPosition, Quaternion.identity);
            AfterimagePlayback playback = instance.GetComponent<AfterimagePlayback>();
            if (playback == null)
            {
                playback = instance.AddComponent<AfterimagePlayback>();
            }

            playback.SetPlaybackData(recorder.RecordedFrames);
            spawnedAfterimages.Add(playback);
        }
    }
}
