using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public float grapplingSpeed;
    Rigidbody2D rigidbody;
    bool grapplingMovement;

    Player playerScript;
    void Start()
    {
        grapplingMovement = false;
        // get player script
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rigidbody = GetComponent<Rigidbody2D>(); // get rigidbody
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // if collides with wall
        if (collider.gameObject.tag == "Wall")
        {
            rigidbody.velocity = new Vector2(0,0); // stop hook movement
            grapplingMovement = true;
        }
    }

    void FixedUpdate()
    {
        if (grapplingMovement)
        {
            // movetowards(this_pos, target, step)
            GameObject.FindGameObjectWithTag("Player").transform.position =
                Vector2.MoveTowards(
                    GameObject.FindGameObjectWithTag("Player").transform.position,
                    transform.position,
                    grapplingSpeed * Time.fixedDeltaTime
                );
        }
    }
}
