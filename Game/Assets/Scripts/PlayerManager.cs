using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    float maxHealth = 100;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = (Slider)GameObject.Find("PlayerHealth").GetComponent<Slider>();;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health / maxHealth;
    }

    public void Die() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BulletHit(float damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }
}
