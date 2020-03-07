using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Controller : MonoBehaviour
{
    public float rotSpeed = 1f;

    Dog_Cursor cursor;
    GameObject ball;
    Dog_Ball dogball;

    void Start() {
        cursor = GameObject.Find("Camera").GetComponent<Dog_Cursor>();
        ball = GameObject.Find("DogBall");
        dogball = ball.GetComponent<Dog_Ball>();
    }

    void FixedUpdate() {
        // DogLookAt(ball.transform.position);
        if (!dogball.isControllingBall) {
            DogMovePosition(ball.transform.position);
        } else {
            DogMovePosition(Vector3.zero);
        }
    }

    private void DogMovePosition(Vector3 target) {
        DogLookAt(target);
        transform.position = Vector3.Lerp(transform.position, target, Time.fixedDeltaTime * 2f);
    }

    private void DogLookAt(Vector3 target) {
        Vector3 lookDirection = new Vector3(target.x, transform.position.y, target.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.position - lookDirection, Vector3.up), rotSpeed * Time.fixedDeltaTime);
    }
}
