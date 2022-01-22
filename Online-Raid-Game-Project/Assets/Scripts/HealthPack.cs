using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    PlayerHealth playerHealthScript;
    float playerHealth, maxHealth;
    public float healValue;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // grab health pack, heal
        if (collider.gameObject.tag == "Player")
        {
            playerHealthScript = collider.gameObject.GetComponent<PlayerHealth>();
            if (playerHealthScript.health < playerHealthScript.baseHealth)
                playerHealthScript.health += healValue;
            Destroy(gameObject);
        }
    }
}