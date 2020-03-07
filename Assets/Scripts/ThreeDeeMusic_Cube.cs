using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDeeMusic_Cube : MonoBehaviour
{
    public int sampleId;

    Dog_Music music;
    float power;
    float currentPower;

    void Start() {
        music = GameObject.Find("Music").GetComponent<Dog_Music>();
        power = 2f;
    }

    void Update() {
        float nextPower = (music.samples[sampleId] + music.samples[sampleId + 1]) * power * (sampleId * 2f + 1);
        if (nextPower > currentPower) {
            currentPower = nextPower;
        } else if (currentPower > 0f) {
            currentPower = Mathf.Clamp(currentPower - Time.deltaTime * currentPower * 4f, 0f, 1000f);
        }

        transform.localScale = new Vector3(Mathf.Clamp(.8f - currentPower * .01f, 0f, 100f), currentPower * .2f + .1f, currentPower * .05f + .1f);
    }
}
