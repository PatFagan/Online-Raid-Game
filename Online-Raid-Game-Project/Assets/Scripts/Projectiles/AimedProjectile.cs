using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile : Photon.MonoBehaviour
{
    public PhotonView photonView;

    Rigidbody2D rigidbody;
    public GameObject deathEffect;
    public float speed;

    Player playerScript;
    GameObject player;

    void Start()
    {
        if (photonView.isMine)
        {
            //print(photonView.gameObject.name);
            player = GameObject.Find("Player1"); // get gameObject owning photonView
            playerScript = player.GetComponent<Player>(); // get player script

            // set direction/speed
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = playerScript.shootingDirection * speed;
        }
    }
}