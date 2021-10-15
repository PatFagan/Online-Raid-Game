using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Photon.MonoBehaviour
{
    public float health, knockbackForce;//, speed;
    private float stunTime, baseHealth, baseSpeed;
    public GameObject deathEffect;
    public SpriteRenderer spriteRenderer;
    public GameObject playerSprite;
    Rigidbody2D enemyRigidbody;
    public string damageTag;

    public bool invincible = false;

    float knockbackTimer; // times the duration of a knockback

    Player playerScript;
    GameInstanceManager gameManagerScript;

    void Start()
    {
        baseHealth = health;
        enemyRigidbody = GetComponent<Rigidbody2D>(); // sets sprite renderer component
        knockbackTimer = 0;

        playerScript = gameObject.GetComponent<Player>();
        baseSpeed = playerScript.moveSpeed;

        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameInstanceManager>();
    }

    void Update()
    {
        // enemy is dead
        if (health <= 0)
        {
            //Debug.Log("player death");
            StartCoroutine(PlayerDeath());
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

        // invincibility transluscence
        if (playerScript.invincible == true)
        {
            spriteRenderer.color -= new Color(0f, 0f, 0f, .9f); // transluscent
        }
        else if (playerScript.invincible == false)
        {
            spriteRenderer.color += new Color(0f, 0f, 0f, 1f); // opaque
        }
    }

    public void DealDamage(int damage)
    {
        if (playerScript.invincible == false)
        {
            health -= damage; // take damage
            stunTime = .2f; // stunned when hit
            //Debug.Log("took damage, health: " + health);
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
            DealDamage(collider.gameObject.GetComponent<Projectile>().damage);
            Knockback();
        }
        if (health <= 0)
        {
            for (int i = 2; i < 7; i++)
            {
                if (collider.gameObject.name == "Player" + i) // if other player hits you, revive
                {
                    RevivedByPlayer(collider);
                }
            }
        }
    }

    IEnumerator PlayerDeath()
    {
        playerScript.moveSpeed = 0f; // stop movement
        playerSprite.transform.Rotate(0f, 0f, 5f, Space.Self); // rotate
        yield return new WaitForSeconds(5); // wait
        Revive();
    }

    void RevivedByPlayer(Collider2D Reviver)
    {
        playerSprite.transform.rotation = Quaternion.identity; // reset rotation
        health = baseHealth; // refill health
        playerScript.moveSpeed = baseSpeed; // set speed back to normal
        // output to reviver feed
        gameManagerScript.ReviveFeed(Reviver.GetComponent<PhotonView>().owner.NickName, 
            gameObject.GetComponent<PhotonView>().owner.NickName);
    }

    void Revive()
    {
        playerSprite.transform.rotation = Quaternion.identity; // reset rotation
        health = baseHealth; // refill health
        playerScript.moveSpeed = baseSpeed; // set speed back to normal
    }
}