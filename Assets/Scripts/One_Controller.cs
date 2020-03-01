using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Controller : MonoBehaviour
{
    public AudioClip[] musics;
    public int actualmusic = 0;

    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        if (musics.Length > 0) {
            actualmusic -= 1;
            changeMusic();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            changeMusic();
        }
    }

    private void changeMusic() {
        actualmusic += 1;
        if (actualmusic >= musics.Length)
        {
            actualmusic = 0;
        }
        audioSource.clip = musics[actualmusic];
        audioSource.Play();
    }
}
