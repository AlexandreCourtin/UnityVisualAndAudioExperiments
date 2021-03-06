﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog_Controller : MonoBehaviour
{
    public float rotSpeed = 1f;
    public float speed = 2f;
    public float distanceToBall = 1f;

    Dog_Cursor cursor;
    GameObject ball;
    Dog_Ball dogball;
    Rigidbody ballRb;
    Animator dogAnimator;
    bool hasBall;
    bool isRunning;
    bool droppedBall;

    void Start() {
        cursor = GameObject.Find("Camera").GetComponent<Dog_Cursor>();
        ball = GameObject.Find("DogBall");
        dogball = ball.GetComponent<Dog_Ball>();
        ballRb = ball.GetComponent<Rigidbody>();
        dogAnimator = GetComponent<Animator>();
        hasBall = false;
        isRunning = false;
        droppedBall = false;
    }

    void FixedUpdate() {
        if (dogball.isControllingBall) {
            droppedBall = false;
            if (Vector3.Distance(transform.position, Vector3.zero) > 1f) {
                DogMovePosition(Vector3.zero);
                DogLookAt(Vector3.zero);
                setRunAnimationState(true);
            } else {
                DogLookAt(ball.transform.position);
                setRunAnimationState(false);
            }
        } else if (hasBall && Vector3.Distance(transform.position, ball.transform.position) > distanceToBall) {
            hasBall = false;
        } else if (!dogball.isControllingBall && Vector3.Distance(transform.position, ball.transform.position) <= distanceToBall && !hasBall) {
            hasBall = true;
            dogball.isInDogMouth = true;
        } else if (!dogball.isControllingBall && Vector3.Distance(transform.position, ball.transform.position) > distanceToBall && !hasBall && !droppedBall) {
            DogMovePosition(ball.transform.position);
            DogLookAt(ball.transform.position);
            setRunAnimationState(true);
        } else if (hasBall && !droppedBall) {
            if (Vector3.Distance(transform.position, Vector3.zero) > 1f) {
                DogMovePosition(Vector3.zero);
                DogLookAt(Vector3.zero);
                setRunAnimationState(true);
            } else {
                setRunAnimationState(false);
                droppedBall = true;
                dogball.isInDogMouth = false;
                ballRb.useGravity = true;
                ballRb.AddForce(-transform.forward * 100f);
            }
        }
    }

    private void setRunAnimationState(bool b) {
        isRunning = b;
        dogAnimator.SetBool("isRunning", isRunning);
    }

    private void DogMovePosition(Vector3 target) {
        Vector3 targetPosition = new Vector3(target.x, transform.position.y, target.z);
        float t = Time.fixedDeltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, t);
    }

    private void DogLookAt(Vector3 target) {
        Vector3 lookDirection = new Vector3(target.x, transform.position.y, target.z);
        Quaternion q = Quaternion.LookRotation(transform.position - lookDirection, Vector3.up);
        float t = Time.fixedDeltaTime * rotSpeed;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, t);
    }
}
