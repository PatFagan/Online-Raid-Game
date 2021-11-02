using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float projectileSpeedX, projectileSpeedY;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(projectileSpeedX, projectileSpeedY);
    }
}