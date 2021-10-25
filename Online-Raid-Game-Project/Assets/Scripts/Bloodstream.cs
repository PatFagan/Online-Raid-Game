using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodstream : Photon.MonoBehaviour
{
    Player playerScript;
    public float baseMoveSpeed;
    public string bloodstreamDirection;

    void OnTriggerStay2D(Collider2D collider)
    {
        for (int i = 1; i < 7; i++)
        {
            if (collider.gameObject.name == "Player" + i) // if other player hits you, revive
            {
                playerScript = collider.gameObject.GetComponent<Player>();
                if (bloodstreamDirection == "Down")
                {
                    if (playerScript.vertical < 0)
                        playerScript.moveSpeed += .25f;
                    else if (playerScript.vertical > 0 && playerScript.moveSpeed >= baseMoveSpeed / 2)
                        playerScript.moveSpeed -= .25f;
                }
                else if (bloodstreamDirection == "Up")
                {
                    if (playerScript.vertical > 0)
                        playerScript.moveSpeed += .25f;
                    else if (playerScript.vertical < 0 && playerScript.moveSpeed >= baseMoveSpeed / 2)
                        playerScript.moveSpeed -= .25f;
                }
                else if (bloodstreamDirection == "Left")
                {
                    if (playerScript.horizontal < 0)
                        playerScript.moveSpeed += .25f;
                    else if (playerScript.horizontal > 0 && playerScript.moveSpeed >= baseMoveSpeed / 2)
                        playerScript.moveSpeed -= .25f;
                }
                else if (bloodstreamDirection == "Right")
                {
                    if (playerScript.horizontal > 0)
                        playerScript.moveSpeed += .25f;
                    else if (playerScript.horizontal < 0 && playerScript.moveSpeed >= baseMoveSpeed / 2)
                        playerScript.moveSpeed -= .25f;
                }
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