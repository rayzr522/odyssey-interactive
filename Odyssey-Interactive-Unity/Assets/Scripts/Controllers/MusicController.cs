using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour {
    private AudioSource source;
    private float volume;

    public float fadeSpeed = 1f;
    public float targetVolume = 1f;

    // Use this for initialization
    void Start() {
        source = GetComponent<AudioSource>();
        source.loop = true;
        source.volume = volume = targetVolume;
    }

    // Update is called once per frame
    void Update() {
        volume = Mathf.Lerp(volume, targetVolume, Time.unscaledDeltaTime * fadeSpeed);
        source.volume = volume;
    }
}
