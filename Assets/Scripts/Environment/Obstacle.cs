using System.Collections.Generic;
using UnityEngine;

namespace Afterimage.Afterimage
{
    public class AfterimageFactory : MonoBehaviour
    {
        [SerializeField] private GameObject afterimagePrefab;

        public AfterimagePlayback SpawnAfterimage(IReadOnlyList<RecordedFrame> frames, Vector3 spawnPosition)
        {
            if (afterimagePrefab == null)
            {
                return null;
            }

            GameObject instance = Instantiate(afterimagePrefab, spawnPosition, Quaternion.identity);
            AfterimagePlayback playback = instance.GetComponent<AfterimagePlayback>();
            if (playback != null)
            {
                playback.SetPlaybackData(frames);
            }

            return playback;
        }
    }
}
