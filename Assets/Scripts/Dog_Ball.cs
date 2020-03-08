using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Ball : MonoBehaviour
{
    public bool isControllingBall;
    public bool isInDogMouth;

    Dog_Cursor cursor;
    Rigidbody ballRb;

    void Start() {
        isControllingBall = false;
        isInDogMouth = false;
        cursor = GameObject.Find("Camera").GetComponent<Dog_Cursor>();
        ballRb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (isInDogMouth) {
            ballRb.useGravity = false;
            ballRb.velocity = Vector3.zero;
            transform.position = GameObject.Find("BallJawPos").transform.position;
        }

        if (Input.GetMouseButton(0)) {
            isControllingBall = true;
            isInDogMouth = false;
            ballRb.useGravity = false;
            ballRb.velocity = Vector3.zero;
            transform.position = cursor.mousePosition;
        } else if (Input.GetMouseButtonUp(0)) {
            isControllingBall = false;
            ballRb.useGravity = true;
            ballRb.velocity = Vector3.zero;
            ballRb.AddForce(Camera.main.transform.forward * 1000f + Vector3.up * 1000f);
        }
    }
}
