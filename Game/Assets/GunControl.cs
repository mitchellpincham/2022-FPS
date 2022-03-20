using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunControl : MonoBehaviour
{

    public int selectedWeapon = 0;

    // public GameObject bullet;
    // public Camera fpsCam;
    // public Transform attackPoint;
    public Text ammoText;
    public Text reloadingText;

    // big sexy block of keycodes for number keys.
    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
         KeyCode.Alpha0
     };

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    Transform GetCurrentWeapon() {
        return transform.GetChild(selectedWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        // to get the variables from the current gun's script
        ProjectileGun gunScript = GetCurrentWeapon().GetComponent<ProjectileGun>();
        
        // activate/deactivate the reloading text.
        reloadingText.enabled = gunScript.reloading;

        ammoText.text = gunScript.totalBullets + "/" + gunScript.bulletsLeft;


        // code to change weapon if there is an input
        bool changeWeapon = true;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {

            selectedWeapon = (selectedWeapon + 1) % transform.childCount;

        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {

            selectedWeapon = selectedWeapon - 1;
            if (selectedWeapon < 0) {
                selectedWeapon = transform.childCount - 1;
            }
        } else {
            changeWeapon = false;
        }

        for (int i = 0; i < transform.childCount && i < keyCodes.Length; i++) {
            if (Input.GetKeyDown(keyCodes[i])) {
                if (i < transform.childCount) {
                    selectedWeapon = i;
                    changeWeapon = true;
                }
            }
        }

        if (changeWeapon) {
            SelectWeapon();
        }
    }

    void SelectWeapon() {
        int i = 0;
        foreach (Transform weapon in transform) {
            
            if (i == selectedWeapon) {
                weapon.gameObject.SetActive(true);
            } else {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
