using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public float vel;
    public float jumpVel;

    public Transform t;
    public Rigidbody rb;
    
    public Vector2 turn;
    public float sensitivity;

    private bool forward;
    private bool backward;
    private bool left;
    private bool right;
    private bool jump;

    void Update() {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        // stop look up wrapping around.
        // if (turn.x < -180) turn.x += 360;
        // if (turn.x > 180) turn.x %= 360;

        // if (turn.y > 90) turn.y = 90;
        // if (turn.y < -90) turn.y = -90;

        // key inputs

        this.forward = Input.GetKey("w");
        this.backward = Input.GetKey("s");
        this.left = Input.GetKey("a");
        this.right = Input.GetKey("d");

        if (Input.GetKeyDown(KeyCode.Space)) {
            this.jump = true;
        }
    }
    void FixedUpdate() {

        float forwardVel = 0f;
        float leftVel = 0f;

        float xVel = 0f;
        float yVel = 0f;
        float zVel = 0f;

        if (this.forward) forwardVel += this.vel;
        if (this.backward) forwardVel -= this.vel;
        if (this.left) leftVel -= this.vel;
        if (this.right) leftVel += this.vel;

        float angle = turn.x * (float)Math.PI / 180f;
        zVel += forwardVel * (float)Math.Cos(angle);
        xVel += forwardVel * (float)Math.Sin(angle);

        angle += (float)Math.PI / 2f;
        zVel += leftVel * (float)Math.Cos(angle);
        xVel += leftVel * (float)Math.Sin(angle);

        if (this.jump) {
            yVel += this.jumpVel;
            this.jump = false;
        }

        this.rb.AddForce(xVel, yVel, zVel, ForceMode.Impulse);

        //t.eulerAngles = new Vector3(0, 0, 0);
    }
}
