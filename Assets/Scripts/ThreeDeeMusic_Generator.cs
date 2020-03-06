using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDeeMusic_Generator : MonoBehaviour
{
    public GameObject tdCube;

    void Start() {
        for (int i = 0 ; i < 300 ; i++) {
            float posX = i % 30;
            float posZ = i / 30;
            GameObject c = Instantiate(tdCube, new Vector3(posX + 10f, 0f, -posZ + 10f), Quaternion.identity);
            c.GetComponent<ThreeDeeMusic_Cube>().sampleId = i;
        }
    }
}
