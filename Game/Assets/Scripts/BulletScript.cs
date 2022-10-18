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
        if (collision.gameObject.tag == "Enemy") {
            if (collision.gameObject.tag != parent.tag) {
                collision.gameObject.GetComponent<EnemyScript>().BulletHit(20);
            }
        }
        else if (collision.gameObject.tag == "Player") {
            if (collision.gameObject.tag != parent.tag) {
                collision.gameObject.GetComponent<PlayerManager>().BulletHit(20);
            }
        }

        // destroy bullet
        if (collision.gameObject.tag != parent.tag) {
            Destroy(gameObject);
        }
    }
}
