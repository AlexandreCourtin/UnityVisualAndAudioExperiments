using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leperv_Cube : MonoBehaviour
{
    public int sampleId;

    Dog_Music music;
    float power;
    float currentPower;
    Vector3 orPosition;

    void Start() {
        music = GameObject.Find("Music").GetComponent<Dog_Music>();
        power = 3f;
        orPosition = transform.position;
    }

    void Update() {
        float nextPower = (music.samples[sampleId] + music.samples[sampleId + 1]) * power * (sampleId * 2f + 1);
        if (nextPower > currentPower) {
            currentPower = nextPower;
        } else if (currentPower > 0f) {
            currentPower = Mathf.Clamp(currentPower - Time.deltaTime * currentPower * 2f, 0f, 1000f);
        }

        transform.position = orPosition + transform.up * (currentPower * .2f + .1f) * .5f;
        transform.localScale = new Vector3(.2f, currentPower * .2f + .1f, 1f);
    }
}
