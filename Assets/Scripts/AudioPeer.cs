using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{
    public Material soundMat;
    public Sprite soundSprite;
    public float redIntensity;
    public float greenIntensity;
    public float blueIntensity;
    public float redMin;
    public float greenMin;
    public float blueMin;
    public float redIntensity2;
    public float greenIntensity2;
    public float blueIntensity2;
    public float redMin2;
    public float greenMin2;
    public float blueMin2;
    public float yFactor = .5f;
    public float yFactor2 = .5f;
    public float power = 10f;
    public float colorPower = 100000f;

    public float[] samples = new float[512];
    public GameObject[] cubes = new GameObject[300];
    public GameObject[] cubes2 = new GameObject[300];
    public GameObject[] cubes3 = new GameObject[300];
    public GameObject[] cubes4 = new GameObject[300];

    AudioSource audioSource;
    Vector3[] orPosition = new Vector3[300];
    Vector3[] orPosition2 = new Vector3[300];
    Vector3[] orPosition3 = new Vector3[300];
    Vector3[] orPosition4 = new Vector3[300];
    float[] currentLength = new float[300];
    int max = 300;

    void Start() {
        audioSource = GetComponent<AudioSource>();

        float radius = 4.5f;
        float radius2 = 4.5f;

        for (int i = 1 ; i < max ; i++) {
            // int j = ShuffleI(i, max);

            cubes[i] = new GameObject("cube" + i);
            cubes[i].AddComponent<SpriteRenderer>();
            cubes[i].GetComponent<SpriteRenderer>().sprite = soundSprite;
            cubes[i].GetComponent<SpriteRenderer>().material = soundMat;
            cubes[i].transform.position = new Vector3(radius * Mathf.Sin(i * .6f * Mathf.Deg2Rad), radius * Mathf.Cos(i * .6f * Mathf.Deg2Rad), 0f);
            cubes[i].transform.eulerAngles = new Vector3(0f, 0f, -i * .6f);
            cubes[i].transform.parent = transform;
            orPosition[i] = cubes[i].transform.position;

            cubes2[i] = new GameObject("cube" + i);
            cubes2[i].AddComponent<SpriteRenderer>();
            cubes2[i].GetComponent<SpriteRenderer>().sprite = soundSprite;
            cubes2[i].GetComponent<SpriteRenderer>().material = soundMat;
            cubes2[i].transform.position = new Vector3(radius * -Mathf.Sin(i * .6f * Mathf.Deg2Rad), radius * -Mathf.Cos(i * .6f * Mathf.Deg2Rad), 0f);
            cubes2[i].transform.eulerAngles = new Vector3(0f, 0f, -i * .6f + 180f);
            cubes2[i].transform.parent = transform;
            orPosition2[i] = cubes2[i].transform.position;

            cubes3[i] = new GameObject("cube" + i);
            cubes3[i].AddComponent<SpriteRenderer>();
            cubes3[i].GetComponent<SpriteRenderer>().sprite = soundSprite;
            cubes3[i].GetComponent<SpriteRenderer>().material = soundMat;
            cubes3[i].transform.position = new Vector3(radius2 * Mathf.Sin(i * .6f * Mathf.Deg2Rad), radius2 * Mathf.Cos(i * .6f * Mathf.Deg2Rad), 0f);
            cubes3[i].transform.eulerAngles = new Vector3(0f, 0f, -i * .6f);
            cubes3[i].transform.parent = transform;
            orPosition3[i] = cubes3[i].transform.position;

            cubes4[i] = new GameObject("cube" + i);
            cubes4[i].AddComponent<SpriteRenderer>();
            cubes4[i].GetComponent<SpriteRenderer>().sprite = soundSprite;
            cubes4[i].GetComponent<SpriteRenderer>().material = soundMat;
            cubes4[i].transform.position = new Vector3(radius2 * -Mathf.Sin(i * .6f * Mathf.Deg2Rad), radius2 * -Mathf.Cos(i * .6f * Mathf.Deg2Rad), 0f);
            cubes4[i].transform.eulerAngles = new Vector3(0f, 0f, -i * .6f + 180f);
            cubes4[i].transform.parent = transform;
            orPosition4[i] = cubes4[i].transform.position;
        }
    }

    void FixedUpdate() {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);

        for (int i = 1 ; i < max ; i++) {
            // int j = ShuffleI(i, max);

            float newLength = samples[i] * power * i * .5f;

            if (newLength < currentLength[i]) {
                currentLength[i] -= Time.fixedDeltaTime * 2f;
            }
            else {
                currentLength[i] = newLength;
            }
            Vector3 newScale = new Vector3(.5f, Mathf.Clamp(currentLength[i], .5f, 100f), 1f);

            cubes[i].transform.position = orPosition[i] + cubes[i].transform.up * currentLength[i] * yFactor;
            cubes[i].transform.localScale = newScale;
            cubes2[i].transform.position = orPosition2[i] + cubes2[i].transform.up * currentLength[i] * yFactor;
            cubes2[i].transform.localScale = newScale;

            cubes3[i].transform.position = orPosition3[i] + cubes3[i].transform.up * currentLength[i] * yFactor2;
            cubes3[i].transform.localScale = newScale;
            cubes4[i].transform.position = orPosition4[i] + cubes4[i].transform.up * currentLength[i] * yFactor2;
            cubes4[i].transform.localScale = newScale;

            float redColor = samples[i] * redIntensity + redMin * Mathf.Clamp(1f - samples[i], 0f, 1f);
            float greenColor = samples[i] * greenIntensity + greenMin * Mathf.Clamp(1f - samples[i], 0f, 1f);
            float blueColor = samples[i] * blueIntensity + blueMin * Mathf.Clamp(1f - samples[i], 0f, 1f);
            Color newColor = new Color(Mathf.Clamp(redColor, 0f, colorPower), Mathf.Clamp(greenColor, 0f, colorPower), Mathf.Clamp(blueColor, 0f, colorPower), Mathf.Clamp(samples[i], .00005f, 1f));
            cubes[i].GetComponent<SpriteRenderer>().material.SetColor("_MainColor", newColor);
            cubes2[i].GetComponent<SpriteRenderer>().material.SetColor("_MainColor", newColor);

            redColor = samples[i] * redIntensity2 + redMin2 * Mathf.Clamp(1f - samples[i], 0f, 1f);
            greenColor = samples[i] * greenIntensity2 + greenMin2 * Mathf.Clamp(1f - samples[i], 0f, 1f);
            blueColor = samples[i] * blueIntensity2 + blueMin2 * Mathf.Clamp(1f - samples[i], 0f, 1f);
            newColor = new Color(Mathf.Clamp(redColor, 0f, colorPower), Mathf.Clamp(greenColor, 0f, colorPower), Mathf.Clamp(blueColor, 0f, colorPower), Mathf.Clamp(samples[i], .00005f, 1f));
            cubes3[i].GetComponent<SpriteRenderer>().material.SetColor("_MainColor", newColor);
            cubes4[i].GetComponent<SpriteRenderer>().material.SetColor("_MainColor", newColor);
        }
    }

    private int ShuffleI(int i, int maxI) {
        if (i % 2 > 0) {
            return i;
        }
        else {
            return maxI - i;
        }
    }
}
