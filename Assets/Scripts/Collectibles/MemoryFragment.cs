using System.Collections.Generic;
using UnityEngine;

namespace Afterimage.Environment
{
    public class EndlessLevelManager : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [SerializeField] private Transform player;
        [SerializeField] private List<GameObject> segmentPrefabs = new();
        [SerializeField] private float spawnDistance = 40f;
        [SerializeField] private float despawnDistance = 120f;
        [SerializeField] private int initialSegments = 6;

        [Header("Runtime")]
        [SerializeField] private float safeStartLength = 30f;

        private readonly Queue<GameObject> spawnedSegments = new();
        private Vector3 nextSpawnPosition;

        private void Start()
        {
            if (player == null)
            {
                player = Camera.main != null ? Camera.main.transform : transform;
            }

            nextSpawnPosition = transform.position;

            for (int i = 0; i < initialSegments; i++)
            {
                CreateSegment();
            }
        }

        private void Update()
        {
            if (player == null)
            {
                return;
            }

            if (Vector3.Distance(player.position, nextSpawnPosition) < spawnDistance)
            {
                CreateSegment();
            }

            while (spawnedSegments.Count > 0)
            {
                GameObject segment = spawnedSegments.Peek();
                if (segment != null && Vector3.Distance(player.position, segment.transform.position) > despawnDistance)
                {
                    spawnedSegments.Dequeue();
                    Destroy(segment);
                }
                else
                {
                    break;
                }
            }
        }

        private void CreateSegment()
        {
            if (segmentPrefabs.Count == 0)
            {
                return;
            }

            GameObject prefab = segmentPrefabs[Random.Range(0, segmentPrefabs.Count)];
            GameObject segment = Instantiate(prefab, nextSpawnPosition, Quaternion.identity);
            segment.transform.SetParent(transform);

            UnderwaterSegment underwaterSegment = segment.GetComponent<UnderwaterSegment>();
            if (underwaterSegment != null)
            {
                nextSpawnPosition += Vector3.forward * underwaterSegment.Length;
            }
            else
            {
                nextSpawnPosition += Vector3.forward * 25f;
            }

            spawnedSegments.Enqueue(segment);
        }
    }

    public class UnderwaterSegment : MonoBehaviour
    {
        [SerializeField] private float length = 25f;
        public float Length => length;
    }
}
