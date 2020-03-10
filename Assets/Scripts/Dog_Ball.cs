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

            float t = Time.fixedDeltaTime * 100f;
            transform.position = Vector3.MoveTowards(transform.position, cursor.mousePosition, t);
        } else if (Input.GetMouseButtonUp(0)) {
            isControllingBall = false;
            ballRb.useGravity = true;
            ballRb.velocity = Vector3.zero;

            Vector3 mouseDirection = (transform.position - Camera.main.transform.position).normalized;
            ballRb.AddForce(mouseDirection * 1000f + Vector3.up * 1000f);
        }
    }
}
