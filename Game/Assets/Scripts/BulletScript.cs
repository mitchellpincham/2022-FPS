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
        // damage the enemy
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyScript>().BulletHit(20);
        }

        // destroy bullet
        Destroy(gameObject);
    }
}
