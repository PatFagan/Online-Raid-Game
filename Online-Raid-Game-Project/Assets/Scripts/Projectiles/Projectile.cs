using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Photon.MonoBehaviour
{
    public float projectileLifespan;
    public GameObject deathEffect;
    public string targetTag;
    public int damage;

    void Start()
    {
        Destroy(gameObject, projectileLifespan); // destroy after lifespan expires
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // if collides with target, destroy
        if (collider.gameObject.tag == targetTag)
        {
            if (deathEffect) { Instantiate(deathEffect, transform.position, Quaternion.identity); }
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "SafeZone") // if collides with water, slow down
        {
            Destroy(gameObject);
        }
    }
}