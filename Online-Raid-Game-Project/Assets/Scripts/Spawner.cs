using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime;
    public GameObject spawnObject;
    float timer;
    public string tagOfSpawnedObject, folder;

    public int MAX_SPAWN_OBJECTS = 10;
    public bool spawnLimit;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime; // timer

        if (timer >= spawnTime)
        {
            if (spawnLimit == false || (GameObject.FindGameObjectsWithTag(tagOfSpawnedObject).Length < MAX_SPAWN_OBJECTS))
            {
                PhotonNetwork.Instantiate(folder + "/" + spawnObject.name, transform.position, Quaternion.identity, 0);
                timer = 0;
            }
        }
    }
}