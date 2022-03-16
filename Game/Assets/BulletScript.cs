using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletScript : MonoBehaviour
{
    public float lifetime;
     
    void Start() {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }
}