using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class One_CircleVisualizer : MonoBehaviour
{
    public Material soundMat;
    public Sprite soundSprite;
    public Vector3 colorIntensity;
    public Vector3 colorMin;
    public float yFactor = .5f;
    public float power = 10f;
    public float colorPower = 100000f;
    public float yFallOff = 2f;
    public float radius = 4.5f;

    float[] samples = new float[512];
    GameObject[] cubes = new GameObject[200];
    GameObject[] cubes2 = new GameObject[200];

    AudioSource audioSource;
    Vector3[] orPosition = new Vector3[200];
    Vector3[] orPosition2 = new Vector3[200];
    float[] currentLength = new float[200];
    int max = 200;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        for (int i = 0 ; i < max ; i++) {
            cubes[i] = new GameObject("cube" + i);
            cubes[i].AddComponent<SpriteRenderer>();
            cubes[i].GetComponent<SpriteRenderer>().sprite = soundSprite;
            cubes[i].GetComponent<SpriteRenderer>().material = soundMat;
            cubes[i].transform.position = new Vector3(radius * Mathf.Sin(i * .9025f * Mathf.Deg2Rad), radius * Mathf.Cos(i * .9025f * Mathf.Deg2Rad), 0f);
            cubes[i].transform.eulerAngles = new Vector3(0f, 0f, -i * .9025f);
            cubes[i].transform.parent = transform;
            orPosition[i] = cubes[i].transform.position;

            cubes2[i] = new GameObject("cube" + i);
            cubes2[i].AddComponent<SpriteRenderer>();
            cubes2[i].GetComponent<SpriteRenderer>().sprite = soundSprite;
            cubes2[i].GetComponent<SpriteRenderer>().material = soundMat;
            cubes2[i].transform.position = new Vector3(radius * -Mathf.Sin(i * .9025f * Mathf.Deg2Rad), radius * Mathf.Cos(i * .9025f * Mathf.Deg2Rad), 0f);
            cubes2[i].transform.eulerAngles = new Vector3(0f, 0f, i * .9025f);
            cubes2[i].transform.parent = transform;
            orPosition2[i] = cubes2[i].transform.position;
        }
    }

    void Update() {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);

        for (int i = 0 ; i < max ; i++) {
            float newLength = ((samples[i] + samples[i + 1]) * power) * (i * 2 + 1) * .01f;

            if (newLength < .1f) {
                currentLength[i] = .3f;
            }
            else if (newLength < currentLength[i]) {
                currentLength[i] -= Time.deltaTime * currentLength[i] * yFallOff;
            }
            else {
                currentLength[i] = newLength;
            }
            Vector3 newScale = new Vector3(.5f, Mathf.Clamp(currentLength[i], 0f, 100f), 1f);

            cubes[i].transform.position = orPosition[i] + cubes[i].transform.up * currentLength[i] * yFactor;
            cubes[i].transform.localScale = newScale;
            cubes2[i].transform.position = orPosition2[i] + cubes2[i].transform.up * currentLength[i] * yFactor;
            cubes2[i].transform.localScale = newScale;

            float redColor = (samples[i] + samples[i + 1]) * colorIntensity.x + colorMin.x * Mathf.Clamp(1f - (samples[i] + samples[i + 1]), 0f, 1f);
            float greenColor = (samples[i] + samples[i + 1]) * colorIntensity.y + colorMin.y * Mathf.Clamp(1f - (samples[i] + samples[i + 1]), 0f, 1f);
            float blueColor = (samples[i] + samples[i + 1]) * colorIntensity.z + colorMin.z * Mathf.Clamp(1f - (samples[i] + samples[i + 1]), 0f, 1f);
            Color newColor = new Color(Mathf.Clamp(redColor, 0f, colorPower), Mathf.Clamp(greenColor, 0f, colorPower), Mathf.Clamp(blueColor, 0f, colorPower), Mathf.Clamp((samples[i] + samples[i + 1]), .00005f, 1f));
            cubes[i].GetComponent<SpriteRenderer>().material.SetColor("_MainColor", newColor);
            cubes2[i].GetComponent<SpriteRenderer>().material.SetColor("_MainColor", newColor);
        }
    }
}
