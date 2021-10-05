using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed;
    private Transform target;
    public string targetTag;

    void FixedUpdate()
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