using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float health;

    // Update is called once per frame
    void Update() {
        
    }

    public void BulletHit(float damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        gameObject.SetActive(false);
    }
}
