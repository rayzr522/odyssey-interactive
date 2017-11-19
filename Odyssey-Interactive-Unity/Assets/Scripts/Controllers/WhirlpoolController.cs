using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlpoolController : MonoBehaviour {

    public float maxPullDistance = 4f;
    public float distanceMultiplier = 0.15f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        PlayerController player = GameController.instance.playerController;

        Vector2 pos = transform.position.to2D();
        Vector2 playerPos = player.transform.position.to2D();

        Vector2 distance = pos - playerPos;
        Vector2 normal = distance.normalized;
        float mag = distance.magnitude / maxPullDistance;


        player.AddVelocity(normal * distanceMultiplier * (1f / (mag * mag)) * Time.deltaTime);
    }
}
