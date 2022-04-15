using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour 
{
    public Transform camera;
    public GameObject player;
    public Vector3 followDistance;

    void Start() {
        // Stop the mouse from moving.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame.
    void Update() {
        // Set the camera position to the player.
        // camera.position = player.transform.position + followDistance;

        Movement movement = player.GetComponent<Movement>();
        // Set the rotation to the players rotation, get the variable from the movement script.
        camera.localRotation = Quaternion.Euler(-movement.turn.y, movement.turn.x, 0f);
        
    }
}
