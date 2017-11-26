// -- ALL HAIL THE GREAT WIGGLER --
// https://giphy.com/gifs/wiggle-shaq-13CoXDiaCcCoyk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIGGLER : MonoBehaviour {
    public float wiggleSpeed = 25f;
    public float wiggleMultiplier = 50f;
    public float baseRotateSpeed = -15f;

    // Update is called once per frame
    void Update() {
        // BEHOLD THE BEAUTIFUL MAAATTHH
        transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * (baseRotateSpeed + Mathf.Sin(Time.time * wiggleSpeed) * wiggleMultiplier)));
    }
}
