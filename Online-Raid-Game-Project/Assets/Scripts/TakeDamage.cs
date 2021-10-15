using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float health, knockbackForce;//, speed;
    private float stunTime;
    public GameObject deathEffect;
    private SpriteRenderer spriteRenderer;
    public string damageTag;

    float knockbackTimer; // times the duration of a knockback

    //SpawnPowerUps powerUpScript;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // sets sprite renderer component
        knockbackTimer = 0;
    }

    void Update()
    {
        // enemy is dead
        if (health <= 0)
        {
            if (deathEffect) { Instantiate(deathEffect, transform.position, Quaternion.identity); }
            Destroy(gameObject);

            //powerUpScript.SpawnPowerUp(transform.position);
        }

        // stunned
        if (stunTime > 0f)
        {
            spriteRenderer.color = Color.red;
            //speed = 0f;
        }
        else if (stunTime <= 0)
        {
            spriteRenderer.color = Color.white;
            //speed = 1f;
        }
        stunTime -= Time.deltaTime; // stun timer
        knockbackTimer -= Time.deltaTime; // knockback timer
    }

    public void DealDamage(int damage)
    {
        health -= damage; // take damage
        stunTime = .2f; // stunned when hit
    }

    public void Knockback()
    {
        knockbackTimer = .1f;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        // while knockback timer is greater than 0, add force to the enemy in the opposite direction of the player
        if (knockbackTimer > 0f)
        {
            Vector3 difference = transform.position - collider.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + difference, 2 * knockbackForce * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // when hit by a player projectile, take damage
        if (collider.gameObject.tag == damageTag) // if collides with water, slow down
        {
            DealDamage(collider.gameObject.GetComponent<Projectile>().damage);
            Knockback();
        }
    }
}