using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadExtender : MonoBehaviour {

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        Head[] heads = GetComponentsInChildren<Head>();

        for (int i = 0; i < heads.Length; i++) {
            Head head = heads[i];
            float offset = Mathf.Sin(Time.time * 8f + i * 30f) + 0.4f;
            head.SetLength(0.45f + offset * 0.08f);
        }
    }
}
