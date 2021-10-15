using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    PlayerHealth playerHealthScript;
    float playerHealth, maxHealth;
    public float healValue;
    void Start()
    {
        playerHealthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        maxHealth = playerHealthScript.baseHealth;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // grab health pack, heal
        if (collider.gameObject.tag == "Player")
        {
            playerHealthScript.health += healValue;
            Destroy(gameObject);
        }
    }
}