using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Photon.MonoBehaviour
{
    public string targetTag;
    public float projectileSpeedX, projectileSpeedY, projectileLifespan;
    public int damage;
    public GameObject deathEffect;

    void Start()
    {
        //rigidbody.velocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity;
        Destroy(gameObject, projectileLifespan);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // if collides with target, deal damage then destroy
        if (collider.gameObject.tag == targetTag)
        {
            if (deathEffect) { Instantiate(deathEffect, transform.position, Quaternion.identity); }
            // GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}