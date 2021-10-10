using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float health, knockbackForce;//, speed;
    private float stunTime;
    public GameObject deathEffect;
    private SpriteRenderer spriteRenderer;
    Rigidbody2D enemyRigidbody;
    public string damageTag;

    public bool invincible = false;

    float knockbackTimer; // times the duration of a knockback

    private Transform playerLoc;

    Player playerScript;

    //SpawnPowerUps powerUpScript;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // sets sprite renderer component
        enemyRigidbody = GetComponent<Rigidbody2D>(); // sets sprite renderer component
        knockbackTimer = 0;

        if (gameObject.tag == "Player")
            playerScript = gameObject.GetComponent<Player>();

        //GameObject powerUpScriptHolder = GameObject.FindGameObjectWithTag("PowerUps");
        //powerUpScript = powerUpScriptHolder.GetComponent<SpawnPowerUps>();
    }

    void Update()
    {
        // enemy is dead
        if (health <= 0)
        {
            if (gameObject.tag != "Player")
            {
                if (deathEffect) { Instantiate(deathEffect, transform.position, Quaternion.identity); }
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Player")
            {
                Debug.Log("player death");
                health = 5;
            }

            //powerUpScript.SpawnPowerUp(transform.position);
        }

        // stunned enemy
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

        if (gameObject.tag == "Player")
        {
            if (playerScript.invincible == true)
            {
                spriteRenderer.color -= new Color(0f, 0f, 0f, .9f); // transluscent
            }
            else if (playerScript.invincible == false)
            {
                spriteRenderer.color += new Color(0f, 0f, 0f, 1f); // opaque
            }
        }
    }

    public void DealDamage(int damage)
    {
        if (gameObject.tag != "Player" || !playerScript.invincible)
        {
            health -= damage; // take damage
            stunTime = .2f; // stunned when hit
            Debug.Log("took damage, health: " + health);
        }
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
            DealDamage(1);
            Knockback();
        }
    }
}