using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime;
    public GameObject enemy;
    float timer;

    const int MAX_ENEMIES = 50;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime; // timer

        if (timer >= spawnTime && GameObject.FindGameObjectsWithTag("Enemy").Length < MAX_ENEMIES)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}