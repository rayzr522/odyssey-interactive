using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
	public float scrollSpeed = 2f;
	public float tileSize = 1f;
	public Vector3 direction = Vector3.forward;

	private Vector3 startPosition;

	void Awake() {
		startPosition = transform.position;
	}

	void Update () {
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
		
		transform.position = startPosition + (direction * newPosition);
	}
}
