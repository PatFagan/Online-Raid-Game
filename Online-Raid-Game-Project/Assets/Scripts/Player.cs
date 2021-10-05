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
    public SpriteRenderer sr;

    private void Awake()
    {
        if (photonView.isMine)
        {
            playerCamera.SetActive(true);
            username.text = PhotonNetwork.playerName;
            username.color = Color.blue;
        }
        else
        {
            username.text = photonView.owner.NickName;
            username.color = Color.cyan;
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

            if (horizontal > 0)
                photonView.RPC("FlipTrue", PhotonTargets.AllBuffered);
            else if (horizontal < 0)
                photonView.RPC("FlipFalse", PhotonTargets.AllBuffered);
        }
    }

    [PunRPC]
    private void FlipTrue()
    {
        sr.flipX = true;
    }

    [PunRPC]
    private void FlipFalse()
    {
        sr.flipX = false;
    }
}