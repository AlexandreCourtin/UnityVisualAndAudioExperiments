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
        power = 4f;
    }

    void Update() {
        float nextPower = music.samples[sampleId] * power * sampleId * .5f + 1f;

        if (nextPower > currentPower) {
            currentPower = nextPower;
        } else if (currentPower > 0f) {
            currentPower = Mathf.Clamp(currentPower - Time.deltaTime * currentPower * 3f, 0f, 1000f);
        }

        transform.localScale = new Vector3(transform.localScale.x, currentPower, transform.localScale.z);
    }
}
