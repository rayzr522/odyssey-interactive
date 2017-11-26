using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScyllaController : MonoBehaviour {
    public float verticalBounds = 4f;
    public float speed = 3f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector2 pos = transform.position.to2D();
        float y = pos.y;

        y += Time.deltaTime * speed;
        if (speed > 0f && y >= verticalBounds) {
            y = verticalBounds;
            speed *= -1;
        } else if (speed < 0f && y <= -verticalBounds) {
            y = -verticalBounds;
            speed *= -1;
        }

        pos.y = y;
        transform.position = pos.to3D();
    }
}
