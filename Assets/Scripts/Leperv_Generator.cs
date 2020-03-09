using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leperv_Generator : MonoBehaviour
{
    public GameObject lpCube;

    void Start() {
        for (int i = 1 ; i < 51 ; i++) {
            float radius = .2f;
            Vector3 pos = new Vector3(radius * Mathf.Sin(i * 6.9f * Mathf.Deg2Rad), radius * Mathf.Cos(i * 6.9f * Mathf.Deg2Rad), 0f);
            GameObject c = Instantiate(lpCube, pos, Quaternion.identity);
            c.transform.eulerAngles = new Vector3(0f, 0f, -i * 6.9f);
            c.GetComponent<Leperv_Cube>().sampleId = i;
        }
    }
}
