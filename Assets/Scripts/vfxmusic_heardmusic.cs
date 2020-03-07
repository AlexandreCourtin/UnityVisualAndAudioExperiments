using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfxmusic_heardmusic : MonoBehaviour
{
    // public float delay = .0155f;
    public float delay = 5f;

    AudioSource music;

    void Start() {
        music = GetComponent<AudioSource>();
        music.clip = GameObject.Find("Music").GetComponent<AudioSource>().clip;
    }

    void Update() {
        delay -= Time.deltaTime;
        if (delay <= 0f) {
            music.Play();
            Destroy(this);
        }
    }
}
