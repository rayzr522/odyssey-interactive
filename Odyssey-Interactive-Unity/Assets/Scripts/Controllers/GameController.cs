using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public enum State {
        STARTING, PLAYING, PAUSED, GAMEOVER
    }

    public static GameController instance {
        get;
        private set;
    }

    public PlayerController playerController;
    public ScyllaController scyllaController;
    public WhirlpoolController whirlpoolController;
    public GameUIController uiController;
    public CameraShake cameraShake;

    public float gameTime = 30f;

    private float _remainingTime;

    public int remainingTime { get { return (int)Math.Ceiling(_remainingTime); } }

    public State state {
        get;
        private set;
    }
    public bool isPlaying {
        get { return state == State.PLAYING; }
    }

    void Awake() {
        instance = this;
        Init();
    }

    void OnDestroy() {
        CleanUp();
    }

    void Init() {
        state = State.PLAYING;
        Time.timeScale = 1f;

        Global.difficulty.Apply(this);

        _remainingTime = gameTime;
    }

    void CleanUp() {
        Time.timeScale = 1f;
        instance = null;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePlayPause();
        }

        if (state == State.PLAYING && playerController.state == PlayerController.State.ALIVE) {
            _remainingTime -= Time.deltaTime;
            if (_remainingTime <= 0f) {
                _remainingTime = 0f;
                EndGame();
            }

            uiController.UpdateClock(remainingTime);
        }
    }

    public void TogglePlayPause() {
        if (state == State.PLAYING) {
            state = State.PAUSED;
            Time.timeScale = 0f;
            uiController.ShowPauseMenu();
        } else if (state == State.PAUSED) {
            state = State.PLAYING;
            Time.timeScale = 1f;
            uiController.HidePauseMenu();
        }
    }

    public void Restart() {
        Global.Scenes.ReloadCurrent();
        // Init();
    }

    public void EndGame() {
        state = State.GAMEOVER;
        ShowGameoverScreen();
    }

    void ShowGameoverScreen() {
        uiController.ShowGameoverScreen(CompileGameResults());
    }

    GameResults CompileGameResults() {
        int health = playerController.health;
        bool won = playerController.state == PlayerController.State.ALIVE;
        DeathReason deathReason = playerController.deathReason;

        return new GameResults(remainingTime, health, won, deathReason);
    }
}
