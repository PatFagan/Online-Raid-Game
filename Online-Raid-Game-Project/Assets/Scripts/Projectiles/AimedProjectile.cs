using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public int damage;
    public GameObject deathEffect;
    public float speed;

    Player playerScript;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // set direction/speed
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = playerScript.movement * speed;
    }
}