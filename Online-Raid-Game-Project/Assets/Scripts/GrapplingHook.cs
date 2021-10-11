using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public float grapplingSpeed;
    Rigidbody2D rigidbody;
    bool grapplingMovement;
    public PhotonView photonView;

    Player playerScript;
    void Start()
    {
        if (photonView.isMine)
        {
            grapplingMovement = false;
            // get player script
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            rigidbody = GetComponent<Rigidbody2D>(); // get rigidbody
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (photonView.isMine)
        {
            // if collides with wall
            if (collider.gameObject.tag == "Wall")
            {
                rigidbody.velocity = new Vector2(0, 0); // stop hook movement
                grapplingMovement = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (photonView.isMine)
        {
            Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            float dist = Mathf.Sqrt(Mathf.Pow(playerPos.x - transform.position.x, 2)
                + Mathf.Pow(playerPos.y - transform.position.y, 2));
            Debug.Log(dist);
            if (dist < 3)
            {
                grapplingMovement = false;
            }
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
}
