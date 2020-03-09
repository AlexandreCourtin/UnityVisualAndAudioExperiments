using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leperv_Skull : MonoBehaviour
{
    public float power = 2f;
    public float fallOf = 2f;
    public int sample = 2;

    Dog_Music music;
    float currentPower;

    void Start() {
        music = GameObject.Find("Music").GetComponent<Dog_Music>();
    }

    void Update() {
        float nextPower = (music.samples[1] + music.samples[2] + music.samples[3]) * power;
        if (nextPower > currentPower) {
            currentPower = nextPower;
        } else if (currentPower > 0f) {
            currentPower = Mathf.Clamp(currentPower - Time.deltaTime * fallOf, 0f, 1000f);
        }

        transform.localScale = new Vector3(.75f + currentPower,
            .75f + currentPower,
            .75f + currentPower);
    }
}
