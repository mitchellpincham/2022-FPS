using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletScript : MonoBehaviour
{
    public float lifetime;

    public GameObject parent;
     
    void Start() {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision) {
        // damage the enemy
        /*if (collision.gameObject.tag == "Enemy") {
            if (collision.gameObject != parent) {
                collision.gameObject.GetComponent<EnemyScript>().BulletHit(20);
            }
        }
        */
        // destroy bullet

        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != parent.tag) {
            Destroy(gameObject);
        }
    }
}
