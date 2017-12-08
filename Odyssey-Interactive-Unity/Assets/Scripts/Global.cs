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
        public float scyllaMinStateTime { get; private set; }
        public float scyllaMaxStateTime { get; private set; }
        public float whirlpoolMaxPullDistance { get; private set; }
        public float whirlpoolDistanceMultiplier { get; private set; }

        internal Difficulty(int id, string name, Color color, float gameTime, float scyllaSpeed, float scyllaNeckMovementSpeed, float scyllaFollowSpeed, float scyllaMinStateTime, float scyllaMaxStateTime, float whirlpoolMaxPullDistance, float whirlpoolDistanceMultiplier) {
            this.id = id;
            this.name = name;
            this.color = color;

            this.gameTime = gameTime;

            this.scyllaSpeed = scyllaSpeed;
            this.scyllaNeckMovementSpeed = scyllaNeckMovementSpeed;
            this.scyllaFollowSpeed = scyllaFollowSpeed;
            this.scyllaMinStateTime = scyllaMinStateTime;
            this.scyllaMaxStateTime = scyllaMaxStateTime;

            this.whirlpoolMaxPullDistance = whirlpoolMaxPullDistance;
            this.whirlpoolDistanceMultiplier = whirlpoolDistanceMultiplier;
        }

        public void Apply(GameController game) {
            game.gameTime = gameTime;

            ScyllaController scylla = game.scyllaController;
            scylla.speed = scyllaSpeed;
            scylla.neckMovementSpeed = scyllaNeckMovementSpeed;
            scylla.followSpeed = scyllaFollowSpeed;
            scylla.minStateTime = scyllaMinStateTime;
            scylla.maxStateTime = scyllaMaxStateTime;

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
            8.1f,
            // scyllaFollowSpeed
            1.2f,
            // scyllaMinStateTime
            0.8f,
            // scyllaMaxStateTime
            1.5f,
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
            10.1f,
            // scyllaFollowSpeed
            1.61f,
            // scyllaMinStateTime
            0.9f,
            // scyllaMaxStateTime
            1.52f,
            // whirlpoolMaxPullDistance
            7.5f,
            // whirlpoolDistanceMultiplier
            5.2f
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
            10.9f,
            // scyllaFollowSpeed
            1.81f,
            // scyllaMinStateTime
            // Go down from Medium difficulty, gives you a chance to breath sometimes
            0.6f,
            // scyllaMaxStateTime
            1.9f,
            // whirlpoolMaxPullDistance
            6.8f,
            // whirlpoolDistanceMultiplier
            6.1f
       );
    }

    public static Difficulty difficulty = Difficulties.MEDIUM;
}