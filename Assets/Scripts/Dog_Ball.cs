using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Ball : MonoBehaviour
{
    Dog_Cursor cursor;
    Rigidbody ballRb;

    void Start() {
        cursor = GameObject.Find("Camera").GetComponent<Dog_Cursor>();
        ballRb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            ballRb.useGravity = false;
            ballRb.velocity = Vector3.zero;
            transform.position = cursor.mousePosition;
        } else if (Input.GetMouseButtonUp(0)) {
            ballRb.useGravity = true;
            ballRb.velocity = Vector3.zero;
            ballRb.AddForce(Camera.main.transform.forward * 1000f + Vector3.up * 1000f);
        }
    }
}
