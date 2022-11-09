using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletholeScript : MonoBehaviour
{
    // The purpose of this is to delete the bullet hole.
    public float lifetime;
    public GameObject parent;
     
    void Start() {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        // if the object the bullet is on gets disabled then the bullet hole should disappear.
        if (!parent.active) {
            Destroy(gameObject);
        }
    }
}
