using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;

    public float horizontal, vertical;
    public float moveSpeed;
    public TMP_Text username;
    public GameObject playerCamera;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody;

    // dodge variables
    float dodgeTimer, dodgeForceX, dodgeForceY;
    // invincibility variables
    public float invincibilityTimer;
    public bool invincible;
    public float dodgeCooldown, dodgeForce;

    public Vector3 movement;
    int index;

    private void Awake()
    {
        index = 1;
        if (photonView.isMine)
        {
            playerCamera.SetActive(true); // activate your camera
            username.text = PhotonNetwork.playerName; // set your username
            username.color = Color.yellow; // username color
            invincible = false;
            gameObject.name = "Player1";
        }
        else
        {
            username.text = photonView.owner.NickName; // set other players' usernames
            username.color = Color.cyan; // username color
            index++;
            gameObject.name = "Player" + index;
        }
    }

    void FixedUpdate()
    {
        if (photonView.isMine)
        {
            // movement
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            movement = new Vector3(horizontal, vertical, 0f);
            transform.position += movement * Time.deltaTime * moveSpeed;

            // sprite flipping
            if (horizontal > 0)
                photonView.RPC("FlipTrue", PhotonTargets.AllBuffered);
            else if (horizontal < 0)
                photonView.RPC("FlipFalse", PhotonTargets.AllBuffered);

            // dodge
            dodgeTimer += Time.deltaTime; // dodge cooldown timer
            invincibilityTimer -= Time.deltaTime;

            if (Input.GetButton("Dodge") && dodgeTimer > dodgeCooldown) // if dodge button pressed, the dodge
            {
                rigidbody.velocity = movement * new Vector2(dodgeForce, dodgeForce);
                dodgeTimer = 0;
                invincibilityTimer = .5f;
            }
            if (invincibilityTimer > 0) // set invincibility
                invincible = true;
            else
                invincible = false;
        }
    }

    // sprite flipping
    [PunRPC]
    private void FlipTrue()
    {
        spriteRenderer.flipX = true;
    }

    [PunRPC]
    private void FlipFalse()
    {
        spriteRenderer.flipX = false;
    }

    // safe zone triggers
    void OnTriggerStay2D(Collider2D collider)
    {
        // when in a safezone, become immune
        if (collider.gameObject.tag == "SafeZone") // if collides with water, slow down
        {
            invincibilityTimer = 1f;
        }
    }
}