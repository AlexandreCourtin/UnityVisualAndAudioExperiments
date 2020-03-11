using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leperv_Generator : MonoBehaviour
{
    public GameObject lpCube;

    void Start() {
        for (int i = 0 ; i < 50 ; i++) {
            float radius = .2f;
            float rot = 7.5f;
            Vector3 pos = new Vector3(radius * Mathf.Sin(i * rot * Mathf.Deg2Rad), radius * Mathf.Cos(i * rot * Mathf.Deg2Rad), 3.5f);
            GameObject c = Instantiate(lpCube, pos, Quaternion.identity);
            c.transform.eulerAngles = new Vector3(0f, 0f, -i * rot);
            c.GetComponent<Leperv_Cube>().sampleId = i + 3;
        }
    }
}
