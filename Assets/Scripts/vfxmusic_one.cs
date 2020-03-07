using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class vfxmusic_one : MonoBehaviour
{
    public int sampleId;

    Dog_Music music;
    VisualEffect vfx;
    float power;
    float currentPower;

    void Start() {
        music = GameObject.Find("Music").GetComponent<Dog_Music>();
        vfx = GetComponent<VisualEffect>();
        power = .3f;
    }

    void Update() {
        float nextPower = (music.samples[sampleId] + music.samples[sampleId + 1]) * power * (sampleId * 2f + 1);

        if (nextPower > currentPower) {
            currentPower = nextPower;
        } else if (currentPower > 0f) {
            currentPower = Mathf.Clamp(currentPower - Time.deltaTime * currentPower * 3f, 0f, 1000f);
        }

        vfx.SetFloat("Sample", currentPower);
    }

    void FixedUpdate() {
        transform.Rotate(new Vector3(.2f, .8f, .1f));
    }
}
