using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectileGun : MonoBehaviour
{
    // bullet
    public GameObject bullet;

    // bullet physics
    public float shootForce;

    // Gun stats
    public float timeBetweenShooting, spread, reloadTime;
    public int magSize;
    public bool allowButtonHold; // semi-auto vs rapidfire
    private int bulletsLeft; // bullets in mag


    // bools
    bool shooting, readyToShoot, reloading;

    // reference
    public Camera fpsCam;
    public Transform attackPoint;

    // bugfixing
    public bool allowInvoke;

    private void Awake() {
        // make sure magazine is full
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    private void Update() {
        MyInput();
    }

    private void MyInput() {

        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        // reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading) {
            Reload();
        }
        // auto reload when no bullets left
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) {
            Reload();
        }

        Debug.Log("Input");
        // shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0) {
            
            Debug.Log("Shooting");
            Shoot();
        }

    }

    private void Shoot() {
        readyToShoot = false;

        bulletsLeft--;

        // find the hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // middle of screen
        RaycastHit hit;

        // check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit)) {
            targetPoint = hit.point;
        } else {
            targetPoint = ray.GetPoint(75); // point far away
        }

        // calculate the direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        // calculate spread here

        // spawned bullet
        GameObject currentBullet = Instantiate(bullet, 
            attackPoint.position, Quaternion.identity);

        // rotate the bullet
        currentBullet.transform.forward = directionWithoutSpread;

        // add forces
        currentBullet.GetComponent<Rigidbody>().AddForce(
            directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        
        // currentBullet.GetComponent<Rigidbody>().AddForce(
        //     fpsCam.transform.up * upwawrdForce, ForceMode.Impulse);

        // Invoke resetShot function
        if (allowInvoke) {
            Invoke("ResetShot", timeBetweenShooting);

        }
        

    }

    private void ResetShot() {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload() {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished() {
        bulletsLeft = magSize;
        reloading = false;
    }
}
