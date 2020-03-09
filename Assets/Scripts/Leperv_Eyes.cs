using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leperv_Eyes : MonoBehaviour
{
    public float power = 2f;
    public float fallOf = 2f;
    public int sample = 2;

    Dog_Music music;
    float currentPower;
    Material leftEye;
    Material rightEye;

    void Start() {
        music = GameObject.Find("Music").GetComponent<Dog_Music>();
        leftEye = transform.Find("Left").GetComponent<MeshRenderer>().material;
        rightEye = transform.Find("Right").GetComponent<MeshRenderer>().material;
    }

    void Update() {
        float nextPower = (music.samples[sample]) * power;
        if (nextPower > currentPower) {
            currentPower = nextPower;
        } else if (currentPower > 0f) {
            currentPower = Mathf.Clamp(currentPower - Time.deltaTime * fallOf, 0f, 1000f);
        }

        leftEye.SetFloat("_Multiple", currentPower - .25f);
        rightEye.SetFloat("_Multiple", currentPower - .25f);
    }
}
