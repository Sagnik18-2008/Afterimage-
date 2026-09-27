using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Afterimage.Progression
{
    [System.Serializable]
    public class PersistentProgress
    {
        public bool tutorialCompleted;
        public List<string> discoveredZones = new();
        public List<string> memoryFragments = new();
        public float bestDistance;
        public List<string> storyDiscoveries = new();
    }

    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }

        [SerializeField] private string saveFileName = "afterimage-save.json";

        public PersistentProgress Progress { get; private set; } = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
            Load();
        }

        public void AddMemoryFragment(string fragmentId)
        {
            if (!Progress.memoryFragments.Contains(fragmentId))
            {
                Progress.memoryFragments.Add(fragmentId);
                Save();
            }
        }

        public void MarkTutorialComplete()
        {
            Progress.tutorialCompleted = true;
            Save();
        }

        public void Save()
        {
            string path = Path.Combine(Application.persistentDataPath, saveFileName);
            File.WriteAllText(path, JsonUtility.ToJson(Progress));
        }

        public void Load()
        {
            string path = Path.Combine(Application.persistentDataPath, saveFileName);
            if (!File.Exists(path))
            {
                return;
            }

            Progress = JsonUtility.FromJson<PersistentProgress>(File.ReadAllText(path));
        }
    }
}
