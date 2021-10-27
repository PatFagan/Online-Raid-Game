using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToChildOfPlayer : MonoBehaviour
{
    public bool onStart;
    public bool onCollision;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (onStart && player)
        {
            transform.position = player.transform.position;
            this.transform.parent = player.transform;
        }
    }

    void Update()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (onCollision)
        {
            // when hit by a player projectile, take damage
            if (collider.gameObject.tag == "Player") // if collides with water, slow down
            {
                print("GRAB");
                transform.position = player.transform.position;
                this.transform.parent = player.transform;
            }
        }
    }
}