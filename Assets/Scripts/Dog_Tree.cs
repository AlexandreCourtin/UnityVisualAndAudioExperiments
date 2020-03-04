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
        currentHeight = 10f;
        transform.eulerAngles = new Vector3(0f, Random.Range(0f, 359f), 0f);
        transform.localScale = new Vector3(Random.Range(.8f, 1.2f), 1f, Random.Range(.8f, 1.2f));
    }

    void Update() {
        float newHeight = 10f - music.samples[randomSample] * 100f;

        if (newHeight < currentHeight) {
            currentHeight = newHeight;
        } else if (currentHeight < 10f) {
            currentHeight += Time.deltaTime * music.samples[randomSample] * 1000f;
        }

        currentHeight = Mathf.Clamp(currentHeight, 5f, 10f);
        transform.Find("Sphere1").localScale = new Vector3(currentHeight, currentHeight, currentHeight);
        transform.Find("Sphere2").localScale = new Vector3(currentHeight, currentHeight, currentHeight);
        transform.Find("Sphere3").localScale = new Vector3(currentHeight, currentHeight, currentHeight);
        transform.Find("Sphere4").localScale = new Vector3(currentHeight, currentHeight, currentHeight);
        transform.Find("Sphere5").localScale = new Vector3(currentHeight, currentHeight, currentHeight);
        transform.Find("Sphere6").localScale = new Vector3(currentHeight, currentHeight, currentHeight);
    }
}
