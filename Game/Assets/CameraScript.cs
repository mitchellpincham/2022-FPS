using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform camera;
    public GameObject player;
    public Vector3 followDistance;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        camera.position = player.transform.position + followDistance;

        Movement movement = player.GetComponent<Movement>();

        camera.localRotation = Quaternion.Euler(-movement.turn.y, movement.turn.x, 0f);
    }
}
