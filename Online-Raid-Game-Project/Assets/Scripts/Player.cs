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

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody;

    // dodge variables
    float dodgeTimer, dodgeForceX, dodgeForceY;
    // invincibility variables
    public float invincibilityTimer;
    public bool invincible;
    public float dodgeCooldown, dodgeForce;

    public Vector3 movement, shootingDirection;

    private void Awake()
    {
        if (photonView.isMine)
        {
            invincible = false;
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
            rigidbody.velocity = movement * moveSpeed;

            // shooting direction
            if (movement.x >= .3f || movement.y >= .3f || movement.x <= -.3f || movement.y <= -.3f)
                shootingDirection = movement;

            // dodge
            dodgeTimer += Time.deltaTime; // dodge cooldown timer
            invincibilityTimer -= Time.deltaTime;

            if (Input.GetButton("Dodge") && dodgeTimer > dodgeCooldown) // if dodge button pressed, the dodge
            {
                rigidbody.AddForce(10f * movement * new Vector2(dodgeForce, dodgeForce), ForceMode2D.Impulse);
                dodgeTimer = 0;
                invincibilityTimer = .5f;
            }
            if (invincibilityTimer > 0) // set invincibility
                invincible = true;
            else
                invincible = false;
        }
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