using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // variables for player
    public float health = 100;
    float maxHealth = 100;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        // find the health slider
        healthSlider = (Slider)GameObject.Find("PlayerHealth").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // update health slider
        healthSlider.value = health / maxHealth;
    }

    public void Die() {
        // restart the game when dies.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BulletHit(float damage) {
        // player is hit by bullet so take damage and die if not enough health
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }
}
