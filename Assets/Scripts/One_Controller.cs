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
    public float[] powersOne;
    public float[] powersTwo;
    public float[] yFactorsOne;
    public float[] yFactorsTwo;
    public float[] yFallOffOne;
    public float[] yFallOffTwo;
    public int actualMusic = 0;
    public int actualColor = 0;
    public int actualPattern = 0;

    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        if (musics.Length > 0) {
            actualMusic -= 1;
            actualColor -= 1;
            actualPattern -= 1;
            changeMusic();
            changeColors();
            changePattern();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            changeMusic();
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            changeColors();
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            changePattern();
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

    private void changePattern() {
        actualPattern += 1;
        if (actualPattern >= powersOne.Length) {
            actualPattern = 0;
        }
        circles[0].power = powersOne[actualPattern];
        circles[0].yFactor = yFactorsOne[actualPattern];
        circles[0].yFallOff = yFallOffOne[actualPattern];
        circles[1].power = powersTwo[actualPattern];
        circles[1].yFactor = yFactorsTwo[actualPattern];
        circles[1].yFallOff = yFallOffTwo[actualPattern];
    }
}
