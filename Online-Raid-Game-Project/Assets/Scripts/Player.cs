using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;

    float horizontal;
    float vertical;
    public float moveSpeed;
    public TMP_Text username;
    public GameObject playerCamera;

    private void Awake()
    {
        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
        }
    }

    void Update()
    {
        if (photonView.isMine)
        {
            // movement
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal, vertical, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
    }
}