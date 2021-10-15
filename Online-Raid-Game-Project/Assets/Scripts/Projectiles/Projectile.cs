using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Photon.MonoBehaviour
{
    public float projectileLifespan;
    public GameObject deathEffect;
    const int NUM_OF_TAGS = 5; 
    public string[] targetTag = new string[NUM_OF_TAGS];
    public int damage;
    int i;

    void Start()
    {
        Destroy(gameObject, projectileLifespan); // destroy after lifespan expires
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // if collides with target, destroy
        for (i = 0; i < targetTag.Length; i++)
        {
            if (collider.gameObject.tag == targetTag[i])
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
}