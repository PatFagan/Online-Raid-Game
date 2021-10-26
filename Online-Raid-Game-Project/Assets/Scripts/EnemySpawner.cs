using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime;
    public GameObject enemy;
    float timer;

    public int MAX_ENEMIES = 10;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime; // timer

        if (timer >= spawnTime && GameObject.FindGameObjectsWithTag("Enemy").Length < MAX_ENEMIES)
        {
            PhotonNetwork.Instantiate("Enemies/" + enemy.name, transform.position, Quaternion.identity, 0);
            timer = 0;
        }
    }
}