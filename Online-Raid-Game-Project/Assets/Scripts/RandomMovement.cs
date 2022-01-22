using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    float dirX, dirY;
    float timer;
    public float timeBetweenPushes;
    Rigidbody2D rigidbody;
    public float scalar;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        timer = timeBetweenPushes;
    }

    // Update is called once per frame
    void Update()
    {
        timer--;

        if (timer < 0)
        {
            dirX = Random.Range(-1f * scalar, 1f * scalar);
            dirY = Random.Range(-1f * scalar, 1f * scalar);

            rigidbody.AddForce(new Vector2(dirX, dirY), ForceMode2D.Impulse);
            timer = timeBetweenPushes;
        }
    }
}