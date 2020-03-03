using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Tree : MonoBehaviour
{
    void Start() {
        transform.eulerAngles = new Vector3(0f, Random.Range(0f, 359f), 0f);
        transform.localScale = new Vector3(Random.Range(.7f, 1.3f), Random.Range(.5f, 2f), Random.Range(.7f, 1.3f));
    }
}
