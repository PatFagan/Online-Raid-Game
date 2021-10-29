using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToChildOfPlayer : MonoBehaviour
{
    public bool onStart;
    public bool onCollision;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (onStart && player)
        {
            transform.position = player.transform.position;
            this.transform.parent = player.transform;
        }
    }

    void Update()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetButton("Drop"))
        {
            if (onCollision)
                StartCoroutine(DropItem());
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (onCollision)
        {
            // if player collides with item, pick up
            if (collider.gameObject.tag == "Player")
            {
                transform.position = player.transform.position;
                this.transform.parent = player.transform;
            }
        }
    }

    IEnumerator DropItem()
    {
        onCollision = false;
        transform.parent = null;
        yield return new WaitForSeconds(1);
        onCollision = true;
    }
}