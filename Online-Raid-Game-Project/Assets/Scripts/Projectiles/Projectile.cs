using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Photon.MonoBehaviour
{
    public float projectileLifespan;
    public GameObject deathEffect;
    const int NUM_OF_TAGS = 5; 
    public string[] destroyTag = new string[NUM_OF_TAGS];
    public int damage;
    int i;
    public bool lifespan = true;

    void Start()
    {
        if (lifespan)
            StartCoroutine(DestroyAtLifespan());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // if collides with target, destroy
        for (i = 0; i < destroyTag.Length; i++)
        {
            if (collider.gameObject.tag == destroyTag[i])
            {
                if (deathEffect) { Instantiate(deathEffect, transform.position, Quaternion.identity); }
                PhotonNetwork.Destroy(gameObject);
            }
            if (collider.gameObject.tag == "SafeZone") // if collides with water, slow down
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }

    IEnumerator DestroyAtLifespan()
    {
        yield return new WaitForSeconds(projectileLifespan);
        PhotonNetwork.Destroy(gameObject); // destroy after lifespan expires

    }
}