using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectile : Photon.MonoBehaviour
{
    public float projectileLifespan;
    public GameObject explosionShard;

    float timer;
    const int NUM_OF_SHARDS = 3;

    void Start()
    {
        timer = projectileLifespan;
    }

    void Update()
    {
        timer -= Time.deltaTime; // timer

        if (timer < .1)
            Explode();
    }

    void Explode()
    {
        for (int i = 0; i < NUM_OF_SHARDS; i++)
        {
            PhotonNetwork.Instantiate("Projectiles/" + explosionShard.name, transform.position, Quaternion.identity, 0);
        }
    }
}