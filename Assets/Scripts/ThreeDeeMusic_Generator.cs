using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeDeeMusic_Generator : MonoBehaviour
{
    public GameObject tdCube;

    void Start() {
        for (int i = 1 ; i < 201 ; i++) {
            float radius = 10f;
            Vector3 pos = new Vector3(radius * Mathf.Sin(i * 1.8f * Mathf.Deg2Rad), radius * Mathf.Cos(i * 1.8f * Mathf.Deg2Rad), 0f);
            GameObject c = Instantiate(tdCube, pos, Quaternion.identity);
            c.transform.eulerAngles = new Vector3(0f, 0f, -i * 1.8f);
            c.GetComponent<ThreeDeeMusic_Cube>().sampleId = i;
        }
    }
}
