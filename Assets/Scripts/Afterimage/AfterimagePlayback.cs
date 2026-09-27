using System;
using System.Collections.Generic;
using UnityEngine;

namespace Afterimage.Afterimage
{
    [Serializable]
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
        [SerializeField] private float recordInterval = 0.1f;
        [SerializeField] private float maxRecordingDuration = 25f;
        [SerializeField] private bool autoRecordOnStart = true;

        [Header("Runtime")]
        [SerializeField] private Transform target;

        private float timer;
        private float elapsedTime;
        private bool isRecording;
        private readonly List<RecordedFrame> recordedFrames = new();
        private string lastAction = "swim";

        public IReadOnlyList<RecordedFrame> RecordedFrames => recordedFrames;
        public bool IsRecording => isRecording;

        private void Start()
        {
            if (autoRecordOnStart)
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
                    Speed = GetSpeedApproximation(),
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

        private float GetSpeedApproximation()
        {
            return Vector3.Distance(target.position, target.position + target.forward * Time.deltaTime) / Time.deltaTime;
        }
    }
}
