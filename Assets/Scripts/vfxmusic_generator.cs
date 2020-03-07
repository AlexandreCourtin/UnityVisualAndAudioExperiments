using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfxmusic_generator : MonoBehaviour
{
    public GameObject cube;

    void Start() {
        for (int i = 0 ; i < 200 ; i++) {
            float posX = i % 20;
            float posY = i / 20;
            GameObject c = Instantiate(cube, new Vector3(posX * 3f - 28.5f, -posY * 3f + 12.5f, 20f), Quaternion.identity);
            c.GetComponent<vfxmusic_one>().sampleId = i * 2;
        }
    }
}
