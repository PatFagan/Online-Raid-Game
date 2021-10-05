using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectile : MonoBehaviour
{
    public string targetTag;
    Rigidbody2D rigidbody;
    public float projectileSpeedX, projectileSpeedY, projectileLifespan;
    public int damage;
    public GameObject deathEffect;
    public GameObject explosionShard;

    float timer;
    const int NUM_OF_SHARDS = 3;

    void Start()
    {
        timer = projectileLifespan;
        rigidbody = GetComponent<Rigidbody2D>();
        //rigidbody.velocity = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity;
        rigidbody.velocity = new Vector2(projectileSpeedX, projectileSpeedY); // set direction/speed
        Destroy(gameObject, projectileLifespan);
    }

    void Update()
    {
        timer -= Time.deltaTime; // timer

        if (timer < .1)
            Explode();
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

    void Explode()
    {
        for (int i = 0; i < NUM_OF_SHARDS; i++)
        {
            Instantiate(explosionShard, transform.position, Quaternion.identity);
        }
    }
}