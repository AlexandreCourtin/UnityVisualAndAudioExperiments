using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Music : MonoBehaviour
{
    public float[] samples = new float[512];

    AudioSource music;

    void Start() {
        music = GetComponent<AudioSource>();
    }

    void Update() {
        music.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
}
