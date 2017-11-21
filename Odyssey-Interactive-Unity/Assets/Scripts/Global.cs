using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Global {
    public struct Scene {
        public Scene(string name) {
            this.name = name;
        }
        public string name { get; private set; }

        public void show() {
            SceneManager.LoadScene(this.name, LoadSceneMode.Single);
        }
    }

    public class Scenes {
        public static readonly Scene MAIN = new Global.Scene("MainMenu");
        public static readonly Scene GAME = new Global.Scene("Game");

        /// Reloads the current scene
        public static void ReloadCurrent() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}