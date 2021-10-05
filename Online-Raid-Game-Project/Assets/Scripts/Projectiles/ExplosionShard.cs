using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionShard : MonoBehaviour
{
    public string targetTag;
    Rigidbody2D rigidbody;
    public float projectileSpeedX, projectileSpeedY, projectileLifespan;
    public int damage;
    public GameObject deathEffect;

    void Start()
    {
        // set direction/speed
        rigidbody = GetComponent<Rigidbody2D>();
        float randomValueX = Random.Range(-10f, 10f);
        float randomValueY = Random.Range(-10f, 10f);
        rigidbody.velocity = new Vector2(randomValueX * projectileSpeedX, randomValueY * projectileSpeedY);
        Destroy(gameObject, projectileLifespan); // destroy after lifespan expires
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