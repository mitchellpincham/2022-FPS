using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletholeScript : MonoBehaviour
{
    public float lifetime;
    public GameObject parent;
     
    void Start() {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!parent.active) {
            Destroy(gameObject);
        }
    }
}
