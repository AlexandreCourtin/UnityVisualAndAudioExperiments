using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Tree : MonoBehaviour
{
    Dog_Music music;
    int randomSample;
    float currentHeight;

    void Start() {
        music = GameObject.Find("Music").GetComponent<Dog_Music>();
        randomSample = Random.Range(1, 20);
        currentHeight = 1.5f;
        transform.eulerAngles = new Vector3(0f, Random.Range(0f, 359f), 0f);
        transform.localScale = new Vector3(Random.Range(.7f, 1.3f), 1f, Random.Range(.7f, 1.3f));
    }

    void Update() {
        float newHeight = 1.5f - music.samples[randomSample] * 5f;

        if (newHeight < currentHeight) {
            currentHeight = newHeight;
        } else if (currentHeight < 1.5f) {
            currentHeight += Time.deltaTime * 2f;
        }

        if (currentHeight > 1.5f) {
            currentHeight = 1.5f;
        }

        transform.localScale = new Vector3(transform.localScale.x, currentHeight, transform.localScale.z);
    }
}
