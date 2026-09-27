using System.Collections.Generic;
using UnityEngine;

namespace Afterimage.Afterimage
{
    [System.Serializable]
    public class RecordedFrame
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public float Time;
        public float Speed;
        public float Depth;
        public string MajorActions;
    }

    public class AfterimageRecorder : MonoBehaviour
    {
        [Header("Recording")]
        [SerializeField] private Transform target;
        [SerializeField] private float recordInterval = 0.1f;
        [SerializeField] private float maxRecordingDuration = 25f;
        [SerializeField] private bool recordOnStart = true;

        private readonly List<RecordedFrame> recordedFrames = new();
        private float timer;
        private float elapsedTime;
        private bool isRecording;
        private string lastAction = "swim";

        public IReadOnlyList<RecordedFrame> RecordedFrames => recordedFrames;
        public bool IsRecording => isRecording;

        private void Start()
        {
            if (recordOnStart)
            {
                StartRecording();
            }
        }

        private void Update()
        {
            if (!isRecording || target == null)
            {
                return;
            }

            timer += Time.deltaTime;
            elapsedTime += Time.deltaTime;

            if (timer >= recordInterval)
            {
                timer = 0f;
                recordedFrames.Add(new RecordedFrame
                {
                    Position = target.position,
                    Rotation = target.rotation,
                    Time = elapsedTime,
                    Speed = CalculateSpeed(),
                    Depth = target.position.y,
                    MajorActions = lastAction
                });
            }

            if (elapsedTime >= maxRecordingDuration)
            {
                StopRecording();
            }
        }

        public void StartRecording()
        {
            recordedFrames.Clear();
            timer = 0f;
            elapsedTime = 0f;
            isRecording = true;
        }

        public void StopRecording()
        {
            isRecording = false;
        }

        public void RecordAction(string action)
        {
            lastAction = string.IsNullOrEmpty(action) ? "swim" : action;
        }

        private float CalculateSpeed()
        {
            return Mathf.Clamp(Vector3.Distance(target.position, target.position + (target.forward * Time.deltaTime)) / Time.deltaTime, 0f, 40f);
        }
    }
}
