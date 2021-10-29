using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorativeShooting : Photon.MonoBehaviour
{
    public float timeBetweenShots, offsetX, offsetY;
    public GameObject projectile;
    public string shootingButton, projectileTag;
    public float randomMin = 1f, randomMax = 1f;
    public int MAX_PROJECTILES;
    Vector3 bulletSpawnPos;
    float timer;
    public bool automatic = false;

    Player playerScript;
    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        float randomValue = Random.Range(randomMin, randomMax);
        bulletSpawnPos = new Vector3(offsetX + randomValue, offsetY + randomValue, 0);
        timer += Time.deltaTime; // timer

        if (automatic == false)
        {
            if (Input.GetButton(shootingButton) && timer >= timeBetweenShots
                && GameObject.FindGameObjectsWithTag(projectileTag).Length < MAX_PROJECTILES)
            {
                Instantiate(projectile, transform.position + bulletSpawnPos, Quaternion.identity);
                timer = 0;
            }
        }
        else if (automatic)
        {
            if (timer >= timeBetweenShots
                && GameObject.FindGameObjectsWithTag(projectileTag).Length < MAX_PROJECTILES)
            {
                Instantiate(projectile, transform.position + bulletSpawnPos, Quaternion.identity);
                timer = 0;
            }
        }
    }
}