using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float projectileSpeedX, projectileSpeedY;
    public float randMin = -10f, randMax = 10f;
    float randomValueX, randomValueY;

    void Start()
    {
        // set direction/speed
        rigidbody = GetComponent<Rigidbody2D>();
        randomValueX = Random.Range(randMin, randMax);
        randomValueY = Random.Range(randMin, randMax);
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(randomValueX * projectileSpeedX, randomValueY * projectileSpeedY);
    }
}