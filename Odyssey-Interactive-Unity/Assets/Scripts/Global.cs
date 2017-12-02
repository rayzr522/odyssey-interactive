using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Global {
    public struct Scene {
        public string name { get; private set; }

        internal Scene(string name) {
            this.name = name;
        }

        public void show() {
            SceneManager.LoadScene(this.name, LoadSceneMode.Single);
        }
    }

    public struct Difficulty {
        public int id { get; private set; }
        public string name { get; private set; }
        public Color color { get; private set; }

        public float gameTime { get; private set; }
        public float scyllaSpeed { get; private set; }
        public float scyllaNeckMovementSpeed { get; private set; }
        public float scyllaFollowSpeed { get; private set; }
        public float whirlpoolMaxPullDistance { get; private set; }
        public float whirlpoolDistanceMultiplier { get; private set; }

        internal Difficulty(int id, string name, Color color, float gameTime, float scyllaSpeed, float scyllaNeckMovementSpeed, float scyllaFollowSpeed, float whirlpoolMaxPullDistance, float whirlpoolDistanceMultiplier) {
            this.id = id;
            this.name = name;
            this.color = color;

            this.gameTime = gameTime;
            this.scyllaSpeed = scyllaSpeed;
            this.scyllaNeckMovementSpeed = scyllaNeckMovementSpeed;
            this.scyllaFollowSpeed = scyllaFollowSpeed;
            this.whirlpoolMaxPullDistance = whirlpoolMaxPullDistance;
            this.whirlpoolDistanceMultiplier = whirlpoolDistanceMultiplier;
        }

        public void Apply(GameController game) {
            game.gameTime = gameTime;

            ScyllaController scylla = game.scyllaController;
            scylla.speed = scyllaSpeed;
            scylla.neckMovementSpeed = scyllaNeckMovementSpeed;
            scylla.followSpeed = scyllaFollowSpeed;

            WhirlpoolController whirlpool = game.whirlpoolController;
            whirlpool.maxPullDistance = whirlpoolMaxPullDistance;
            whirlpool.distanceMultiplier = whirlpoolDistanceMultiplier;
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

    public class Difficulties {
        public static readonly Difficulty EASY = new Global.Difficulty(
            // id
            0,
            // name
            "Easy",
            // color
            new Color(0.65f, 1f, 0.65f),
            // gameTime
            60f,
            // scyllaSpeed
            2f,
            // scyllaNeckMovementSpeed
            7.5f,
            // scyllaFollowSpeed
            1.2f,
            // whirlpoolMaxPullDistance
            7.5f,
            // whirlpoolDistanceMultiplier
            4.75f
        );

        public static readonly Difficulty MEDIUM = new Global.Difficulty(
            // id
            1,
            // name
            "Medium",
            // color
            new Color(1f, 0.94f, 0.65f),
            // gameTime
            90f,
            // scyllaSpeed
            3f,
            // scyllaNeckMovementSpeed
            9.8f,
            // scyllaFollowSpeed
            1.4f,
            // whirlpoolMaxPullDistance
            7.5f,
            // whirlpoolDistanceMultiplier
            4.75f
       );

        public static readonly Difficulty HARD = new Global.Difficulty(
            // id
            2,
            // name
            "Hard",
            // color
            new Color(1f, 0.5f, 0.5f),
            // gameTime
            180f,
            // scyllaSpeed
            4f,
            // scyllaNeckMovementSpeed
            10.6f,
            // scyllaFollowSpeed
            1.57f,
            // whirlpoolMaxPullDistance
            6f,
            // whirlpoolDistanceMultiplier
            5.8f
       );
    }

    public static Difficulty difficulty = Difficulties.MEDIUM;
}