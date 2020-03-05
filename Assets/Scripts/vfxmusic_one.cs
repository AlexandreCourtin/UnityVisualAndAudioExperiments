using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class vfxmusic_one : MonoBehaviour
{
    public int sampleId;

    AudioSource music;
    VisualEffect vfx;
    float power;
    float[] samples = new float[512];
    float currentPower;

    void Start() {
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        vfx = GetComponent<VisualEffect>();
        power = 2.5f;
    }

    void Update() {
        music.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        float nextPower = samples[sampleId] * power * sampleId * .5f;

        if (nextPower > currentPower) {
            currentPower = nextPower;
        } else if (currentPower > 0f) {
            currentPower -= Time.deltaTime * currentPower * 2f;
        }

        vfx.SetFloat("Sample", currentPower);
    }

    void FixedUpdate() {
        transform.Rotate(new Vector3(.2f, .8f, .1f));
    }
}
