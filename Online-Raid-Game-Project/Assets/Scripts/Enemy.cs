using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health, speed, knockbackForce;
    private float stunTime;
    public GameObject deathEffect;
    private SpriteRenderer spriteRenderer;
    Rigidbody2D enemyRigidbody;

    public bool cameraShake = false, invincible = false;
    public int damage;

    float knockbackTimer; // times the duration of a knockback

    private Transform playerLoc;

    //SpawnPowerUps powerUpScript;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // sets sprite renderer component
        enemyRigidbody = GetComponent<Rigidbody2D>(); // sets sprite renderer component
        knockbackTimer = 0;

        //GameObject powerUpScriptHolder = GameObject.FindGameObjectWithTag("PowerUps");
        //powerUpScript = powerUpScriptHolder.GetComponent<SpawnPowerUps>();
    }

    void Update()
    {
        // enemy is dead
        if (health <= 0)
        {
            Destroy(gameObject);
            if (deathEffect) { Instantiate(deathEffect, transform.position, Quaternion.identity); }
            //powerUpScript.SpawnPowerUp(transform.position);
        }

        // stunned enemy
        if (stunTime > 0f)
        {
            spriteRenderer.color = Color.red;
            speed = 0f;
        }
        else if (stunTime <= 0)
        {
            spriteRenderer.color = Color.white;
            speed = 1f;
        }
        stunTime -= Time.deltaTime; // stun timer
        knockbackTimer -= Time.deltaTime; // knockback timer
    }

    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            health -= damage; // take damage
            stunTime = .2f; // stunned when hit
            Debug.Log("took damage, health: " + health);
        }
    }

    IEnumerator Flash()
    {
        spriteRenderer.color = Color.blue;
        cameraShake = true;
        yield return new WaitForSeconds(1);
        spriteRenderer.color = Color.white;
        cameraShake = false;
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
        if (collider.gameObject.tag == "PlayerProjectile") // if collides with water, slow down
        {
            TakeDamage(1);
            Knockback();
        }
    }
}