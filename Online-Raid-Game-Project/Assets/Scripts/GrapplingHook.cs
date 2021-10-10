using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public float speed; 

    Player playerScript;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // set direction/speed
        playerScript.movement = Vector2.MoveTowards(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position, speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // if collides with target, destroy
        if (collider.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
