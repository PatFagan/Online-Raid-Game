using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile : Photon.MonoBehaviour
{
    Rigidbody2D rigidbody;
    public GameObject deathEffect;
    public float speed;

    Player playerScript;
    GameObject player;

    void Start()
    {
        //print(photonView.gameObject.name);
        player = GameObject.Find("Player1"); // get gameObject owning photonView
        playerScript = player.GetComponent<Player>(); // get player script

        // set direction/speed
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = playerScript.movement * speed;
    }
}