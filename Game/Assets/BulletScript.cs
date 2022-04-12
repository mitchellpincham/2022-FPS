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
        EnemyScript script = collision.gameObject.GetComponent<EnemyScript>();
        script.BulletHit(20);
        Destroy(gameObject);
    }
}
