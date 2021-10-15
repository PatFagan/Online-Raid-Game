using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodstream : Photon.MonoBehaviour
{
    Player playerScript;
    public float baseMoveSpeed;

    void OnTriggerStay2D(Collider2D collider)
    {
        for (int i = 1; i < 7; i++)
        {
            if (collider.gameObject.name == "Player" + i) // if other player hits you, revive
            {
                playerScript = collider.gameObject.GetComponent<Player>();
                if (playerScript.vertical < 0)
                    playerScript.moveSpeed += 1f; 
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        for (int i = 1; i < 7; i++)
        {
            if (collider.gameObject.name == "Player" + i) // if other player hits you, revive
            {
                collider.gameObject.GetComponent<Player>().moveSpeed = baseMoveSpeed;
            }
        }
    }
}