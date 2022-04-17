using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    public float maxHealth;
    public float health;
    public Transform player;

    void Start() {
        health = maxHealth;
    }

    void Update() {
        Slider healthSlider = (Slider)gameObject.GetComponentInChildren(typeof(Slider));

        healthSlider.value = health / maxHealth;

        //transform.LookAt(player);
        float dx = player.position.x - transform.position.x;
        float dz = player.position.z - transform.position.z;

        float ang = (float)Math.Atan2(dx, dz) * 180 / (float)Math.PI;

        transform.rotation = Quaternion.Euler(new Vector3(0, ang, 0));
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
