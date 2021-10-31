using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string collisionTag;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == collisionTag)
        {
            Destroy(gameObject);
        }
    }
}