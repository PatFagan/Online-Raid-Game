using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string targetTag;
    Rigidbody2D rigidbody;
    public float projectileSpeedX, projectileSpeedY, projectileLifespan;
    public int damage;
    public GameObject deathEffect;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //rigidbody.velocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity;
        rigidbody.velocity = new Vector2(projectileSpeedX, projectileSpeedY); // set direction/speed
        Destroy(gameObject, projectileLifespan); // destroy projectile if no collision detected in x seconds
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