using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : Photon.MonoBehaviour
{
    public float speed;
    private Transform target;
    public string targetTag;
    public PhotonView photonView;

    void FixedUpdate()
    {
        if (photonView.isMine)
        {
            if (GameObject.FindGameObjectWithTag(targetTag))
            {
                // get target
                target = GameObject.FindGameObjectWithTag(targetTag).GetComponent<Transform>();
                // move towards target
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            }
        }
    }
}