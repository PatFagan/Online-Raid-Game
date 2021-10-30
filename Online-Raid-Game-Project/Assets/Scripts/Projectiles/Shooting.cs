using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Photon.MonoBehaviour
{
    public float timeBetweenShots, offsetX, offsetY;
    public GameObject projectile;
    public PhotonView photonView;
    public string shootingButton, projectileTag;
    public float randomMin = 1f, randomMax = 1f;
    public int MAX_PROJECTILES;
    Vector3 bulletSpawnPos;
    float timer;
    public bool automatic = false;

    Player playerScript;
    void Start()
    {
        bulletSpawnPos = new Vector3(offsetX, offsetY, 0);
        timer = 0;
    }

    void Update()
    {
        if (photonView.isMine)
        {
            float randomValue = Random.Range(randomMin, randomMax);
            timer += Time.deltaTime; // timer

            if (automatic == false)
            {
                if (Input.GetButton(shootingButton) && timer >= timeBetweenShots
                    && GameObject.FindGameObjectsWithTag(projectileTag).Length < MAX_PROJECTILES)
                {
                    PhotonNetwork.Instantiate("Projectile/" + projectile.name, transform.position + (bulletSpawnPos * randomValue), Quaternion.identity, 0);
                    timer = 0;
                }
            }
            else if (automatic)
            {
                if (timer >= timeBetweenShots
                    && GameObject.FindGameObjectsWithTag(projectileTag).Length < MAX_PROJECTILES)
                {
                    PhotonNetwork.Instantiate("Projectile/" + projectile.name, transform.position + (bulletSpawnPos * randomValue), Quaternion.identity, 0);
                    timer = 0;
                }
            }
        }        
    }
}