using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShooting : Photon.MonoBehaviour
{
    public float timeBetweenShots, offsetX, offsetY;
    public GameObject projectile;
    public PhotonView photonView;

    Vector3 bulletSpawnPos;
    float timer;

    void Start()
    {
        bulletSpawnPos = new Vector3(offsetX, offsetY, 0);
        timer = 0;
    }

    void Update()
    {
        if (photonView.isMine)
        {
            timer += Time.deltaTime; // timer

            if (timer >= timeBetweenShots)
            {
                PhotonNetwork.Instantiate("Projectiles/" + projectile.name, transform.position + bulletSpawnPos, Quaternion.identity, 0);
                timer = 0;
            }
        }

    }
}