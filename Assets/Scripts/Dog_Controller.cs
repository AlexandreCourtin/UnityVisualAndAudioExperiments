using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Controller : MonoBehaviour
{
    public float rotSpeed = 1f;

    Dog_Cursor cursor;

    void Start() {
        cursor = GameObject.Find("Camera").GetComponent<Dog_Cursor>();
    }

    void FixedUpdate() {
        DogLookAt(cursor.mousePosition);
    }

    private void DogLookAt(Vector3 target) {
        Vector3 lookDirection = new Vector3(target.x, transform.position.y, target.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(transform.position - lookDirection, Vector3.up), rotSpeed * Time.fixedDeltaTime);
    }
}
