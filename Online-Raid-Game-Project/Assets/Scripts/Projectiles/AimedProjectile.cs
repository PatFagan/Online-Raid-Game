using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile : Photon.MonoBehaviour
{
    Rigidbody2D rigidbody;
    public GameObject deathEffect;
    public float speed;

    Player playerScript;
    public PhotonView photonView;

    void Start()
    {
        if (photonView.isMine)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            // set direction/speed
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.velocity = playerScript.movement * speed;
        }
    }
}