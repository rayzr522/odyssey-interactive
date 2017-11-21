using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public enum State {
        STARTING, PLAYING, PAUSED, END
    }

    public static GameController instance {
        get;
        private set;
    }

    public PlayerController playerController;
    public ScyllaController scyllaController;
    public WhirlpoolController whirlpoolController;
    public GameUIController uiController;

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
        // Debug.Log("GameController.Init() @ " + Time.time);
    }

    void CleanUp() {
        Time.timeScale = 1f;
        instance = null;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePlayPause();
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
}
