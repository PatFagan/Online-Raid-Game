using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float timeBetweenShots, offsetX, offsetY;
    public GameObject projectile;

    Vector3 bulletSpawnPos;
    float timer;

    void Start()
    {
        bulletSpawnPos = new Vector3(offsetX, offsetY, 0);
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime; // timer

        if (Input.GetButton("Shoot") && timer >= timeBetweenShots)
        {
            Instantiate(projectile, transform.position + bulletSpawnPos, Quaternion.identity);
            timer = 0;
        }
    }
}