using System;
using UnityEngine;

namespace Afterimage.Gameplay
{
    public enum GameStateType
    {
        MainMenu,
        Tutorial,
        StartingRun,
        Playing,
        Checkpoint,
        RunFailed,
        RunCompleted,
        Paused,
        Base,
        FinalSequence
    }

    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager Instance { get; private set; }

        public GameStateType CurrentState { get; private set; } = GameStateType.MainMenu;

        public event Action<GameStateType> StateChanged;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void SetState(GameStateType nextState)
        {
            if (CurrentState == nextState)
            {
                return;
            }

            CurrentState = nextState;
            StateChanged?.Invoke(CurrentState);
        }

        public bool IsGameRunning()
        {
            return CurrentState == GameStateType.StartingRun || CurrentState == GameStateType.Playing || CurrentState == GameStateType.Checkpoint;
        }
    }
}
