using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController instance {
        get;
        private set;
    }

    public PlayerController playerController;
    public ScyllaController scyllaController;
    public WhirlpoolController whirlpoolController;
    public GameUIController uiController;

    void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
