using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour {

    public float range = 5.0f;
    public float speed = 1.0f;

    public float startY;

    private float oldScreenHeight;

    void Awake() {
        startY = transform.localPosition.y;
        oldScreenHeight = Screen.height;
    }

    void Update() {
        float newScreenHeight = Screen.height;

        if (oldScreenHeight != newScreenHeight) {
            startY *= (newScreenHeight / oldScreenHeight);
            oldScreenHeight = newScreenHeight;
        }

        Vector3 position = transform.localPosition;
        position.y = startY + Mathf.Sin(Time.time * speed) * range;
        transform.localPosition = position;
    }
}
