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

    // navmesh stuff
    private NavMeshAgent agent;
    public Transform movePositionTransform;

    public LayerMask whatIsGround, whatIsPlayer;

    // patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void Awake() {
        health = maxHealth;

        // set the navmesh object
        agent = GetComponent<NavMeshAgent>();
    }

    void SearchWalkPoint() {
        // find random point in the range and navmesh
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        
        // set the new walkpoint
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // if the walkpoint is good, then walkPointSet = true.
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) {
            walkPointSet = true;
        }
    }

    void Patroling() {
        // if no walkpoint is set then set one
        if (!walkPointSet) {
            SearchWalkPoint();
        }
        // walk to walkpoint
        if (walkPointSet) {
            agent.SetDestination(walkPoint);
        }

        Vector3 walkPointDistance = transform.position - walkPoint;

        // if close to walkpoint then generate new walkpoint next turn
        if (walkPointDistance.magnitude < 1f) {
            walkPointSet = false;
        }
    }

    void ChasePlayer() {
        // if player is in sight, then move towards him.
        agent.SetDestination(player.transform.position);
    }

    void AttackPlayer() {
        // if the player is in the attack range then dont move and shoot him.
        agent.SetDestination(transform.position);
    }

    void Update() {

        // set ai destination to the transfrom
        //agent.destination = movePositionTransform.position;
        
        // distance to player, will be a float
        Vector3 playerDistance = player.transform.position - transform.position;

        playerInAttackRange = false;
        playerInSightRange = false;

        // if the distance to player is within attack range
        if (playerDistance.magnitude < attackRange) {
            playerInAttackRange = true;
        }
        // if the distance to player is within sight range
        if (playerDistance.magnitude < sightRange) {
            playerInSightRange = true;
        }

        // call the movement functions depending on what the ai can see
        if (!playerInSightRange && !playerInAttackRange) { // patrol
            Debug.Log("patroling");
            Patroling();
        } else if (!playerInAttackRange) {                 // chase
            Debug.Log("chasing");
            ChasePlayer();
        } else {                                           // attack
            Debug.Log("attacking");
            AttackPlayer();
        } 


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
