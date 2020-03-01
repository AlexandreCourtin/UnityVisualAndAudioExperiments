using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_Controller : MonoBehaviour
{
    public AudioClip[] musics;
    public One_CircleVisualizer[] circles;
    public Vector3[] oneColorsIntensity;
    public Vector3[] twoColorsIntensity;
    public Vector3[] oneColorsMin;
    public Vector3[] twoColorsMin;
    public int actualMusic = 0;
    public int actualColor = 0;

    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        if (musics.Length > 0) {
            actualMusic -= 1;
            actualColor -= 1;
            changeMusic();
            changeColors();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            changeMusic();
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            changeColors();
        }
    }

    private void changeMusic() {
        actualMusic += 1;
        if (actualMusic >= musics.Length) {
            actualMusic = 0;
        }
        audioSource.clip = musics[actualMusic];
        audioSource.Play();
    }

    private void changeColors() {
        actualColor += 1;
        if (actualColor >= oneColorsIntensity.Length) {
            actualColor = 0;
        }
        circles[0].colorIntensity = oneColorsIntensity[actualColor];
        circles[0].colorMin = oneColorsMin[actualColor];
        circles[1].colorIntensity = twoColorsIntensity[actualColor];
        circles[1].colorMin = twoColorsMin[actualColor];
    }
}
