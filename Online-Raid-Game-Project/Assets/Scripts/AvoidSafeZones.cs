using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidSafeZones : MonoBehaviour
{
    Follow followScript;

    void Start()
    {
        followScript = gameObject.GetComponent<Follow>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // when in a safezone, become immune
        if (collider.gameObject.tag == "SafeZone") // if collides with water, slow down
        {
            print("run away");
            followScript.speed *= -1f;
            StartCoroutine(TurnBackAround());
        }
    }

    IEnumerator TurnBackAround()
    {
        yield return new WaitForSeconds(1);
        followScript.speed *= -1f;
    }
}