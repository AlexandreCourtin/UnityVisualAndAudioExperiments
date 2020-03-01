using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeerTwo : MonoBehaviour
{
    public Material soundMat;

    public float power = 10f;
    public float grav = 2f;

    public float[] samples = new float[512];

    AudioSource audioSource;
    GameObject lineRenderer;
    LineRenderer lr;
    float[] currentLength = new float[512];

    void Start() {
        audioSource = GetComponent<AudioSource>();

        lineRenderer = new GameObject("line");
        lr = lineRenderer.AddComponent<LineRenderer>();
        lr.material = soundMat;
        lr.positionCount = currentLength.Length;
        lr.startWidth = .1f;
        lr.endWidth = .1f;
    }

    void FixedUpdate() {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);

        for (int i = 0 ; i < currentLength.Length ; i++) {
            float newLength = samples[i] * power * i * .8f;

            if (newLength <= .001f) {
                currentLength[i] = 0f;
            }
            else if (newLength < currentLength[i]) {
                currentLength[i] -= Time.fixedDeltaTime * grav;
            }
            else {
                currentLength[i] = newLength;
            }

            lr.SetPosition(i, new Vector3(-(currentLength.Length * .05f) + i * .1f, currentLength[i], 0f));
        }
    }
}
