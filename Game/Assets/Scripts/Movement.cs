using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    // vel to add to player when they move or jump.
    public float vel;
    public float jumpVel;

    public Transform t;
    public Rigidbody rb;
    
    public Vector2 turn;
    public float sensitivity;

    // whether the player is holding the key down.
    private bool forward;
    private bool backward;
    private bool left;
    private bool right;
    private bool jump;

    void Update() {
        // set the amount to move camera.
        // so the camera doesn't snap when the player resumes the game
        if (Cursor.lockState == CursorLockMode.Locked) {
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        }

        // stop look up wrapping around.
        if (turn.x < -180) turn.x += 360;
        if (turn.x > 180) turn.x %= 360;

        if (turn.y > 90) turn.y = 90;
        if (turn.y < -90) turn.y = -90;

        // key inputs
        this.forward = Input.GetKey("w");
        this.backward = Input.GetKey("s");
        this.left = Input.GetKey("a");
        this.right = Input.GetKey("d");
        this.jump = Input.GetKeyDown(KeyCode.Space);

    }
    void FixedUpdate() {
        
        // the values to move the player forward, back, left and right.
        float forwardVel = 0f;
        float leftVel = 0f;

        // then convert the values to x, y, z to add force.
        float xVel = 0f;
        float yVel = 0f;
        float zVel = 0f;

        // add the force according to the input.
        if (this.forward) forwardVel += this.vel;
        if (this.backward) forwardVel -= this.vel;
        if (this.left) leftVel -= this.vel;
        if (this.right) leftVel += this.vel;

        // convert to x, y, z.
        float angle = turn.x * (float)Math.PI / 180f;
        zVel += forwardVel * (float)Math.Cos(angle);
        xVel += forwardVel * (float)Math.Sin(angle);

        angle += (float)Math.PI / 2f;
        zVel += leftVel * (float)Math.Cos(angle);
        xVel += leftVel * (float)Math.Sin(angle);
        
        // jumping force.
        if (this.jump) {
            yVel += this.jumpVel;
            this.jump = false;
        }

        // Add the force.
        this.rb.AddForce(xVel, yVel, zVel, ForceMode.Impulse);

        t.eulerAngles = new Vector3(0, 0, 0);
    }
}
