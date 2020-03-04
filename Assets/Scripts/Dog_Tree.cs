using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Tree : MonoBehaviour
{
    Dog_Music music;
    int randomSample;
    float currentHeight;

    int[] importantSamples = {3, 13, 23, 33, 43, 53};

    void Start() {
        music = GameObject.Find("Music").GetComponent<Dog_Music>();
        randomSample = Random.Range(0, 100);
        currentHeight = 1f;
        transform.eulerAngles = new Vector3(0f, Random.Range(0f, 359f), 0f);
        transform.localScale = new Vector3(Random.Range(.8f, 1.2f), 1f, Random.Range(.8f, 1.2f));
    }

    void Update() {
        float newHeight = 1f - music.samples[randomSample] - music.samples[randomSample + 1] - music.samples[randomSample + 2];

        if (newHeight < currentHeight) {
            currentHeight -= music.samples[randomSample] * 2f;
        } else if (currentHeight < 1f) {
            currentHeight += Time.deltaTime * .5f + music.samples[randomSample] * .5f;
        }

        currentHeight = Mathf.Clamp(currentHeight, .1f, 1f);
        transform.localScale = new Vector3(transform.localScale.x, currentHeight, transform.localScale.z);
    }
}
