using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour {

	public float xRange = 5.0f;
	public float yRange = 5.0f;
	public float zRange = 5.0f;
	public float speed = 1.0f;

	public Vector3 basePos;

	void Awake() {
		basePos = transform.position;
	}

	void Update () {
		float sin = Mathf.Sin (Time.time * speed);
		float cos = Mathf.Cos (Time.time * speed);

		transform.position = basePos + new Vector3 (cos * xRange, sin * yRange, cos * zRange);
	}
}
