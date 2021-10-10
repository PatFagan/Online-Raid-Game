using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float projectileSpeedX, projectileSpeedY;

    void Start()
    {
        // set direction/speed
        rigidbody = GetComponent<Rigidbody2D>();
        float randomValueX = Random.Range(-10f, 10f);
        float randomValueY = Random.Range(-10f, 10f);
        rigidbody.velocity = new Vector2(randomValueX * projectileSpeedX, randomValueY * projectileSpeedY);
    }
}