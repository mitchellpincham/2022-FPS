using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public float maxHealth;
    public float health;
    public GameObject player;
    private NavMeshAgent navMeshAgent;
    public Transform movePositionTransform;

    // patroling
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;

    // attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // states
    public float sightRange, attackRange;

    void Awake() {
        health = maxHealth;

        // set the navmesh object
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Patroling() {

    }

    void ChasePlayer() {

    }

    void AttackPlayer() {

    }

    void Update() {

        navMeshAgent.destination = movePositionTransform.position;




        // set the health bar value
        Slider healthSlider = (Slider)gameObject.GetComponentInChildren(typeof(Slider));

        healthSlider.value = health / maxHealth;

        // look at player along two axis;
        //transform.LookAt(player.transform);
        float dx = player.transform.position.x - transform.position.x;
        float dz = player.transform.position.z - transform.position.z;

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
