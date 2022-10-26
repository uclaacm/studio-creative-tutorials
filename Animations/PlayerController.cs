using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    bool grounded = true;
    [SerializeField] float speed = 3f;
    [SerializeField] float jumpForce = 200f;

    [Header("Camera")]
    Vector3 cameraPos; //camera position
    [SerializeField] Camera mainCamera;

    //Animations
    SpriteRenderer sprite;
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // references player's rigidbody 2d
        coll = GetComponent<Collider2D>(); //player's collider
        mainCamera = Camera.main; //get the main camera

        if (mainCamera) // if main camera exists
        {
            cameraPos = mainCamera.transform.position; // reference camera position
        }

        // Animations
        sprite = GetComponent<SpriteRenderer>(); // get the player's sprite renderer component
        anim = GetComponent<Animator>(); // get the player's animator component
    }

    private void Update()
    {
        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, cameraPos.y, cameraPos.z);
        }

        grounded = IsGrounded(); // check if player is grounded

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) // if the player is grounded, not falling, and jump key pressed (update: getkeydown is detected every update)
        {
            
            if(grounded)
            {
                rb.AddForce(Vector2.up * jumpForce); // add jump force upward
            }
        }

        float horizontal = Input.GetAxis("Horizontal"); // horizontal movement
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); // move left and right

        // UNCOMMENT FOR ANIMATIONS
        // Animate(); //show animations
    }

    // check grounded
    private bool IsGrounded() //https://www.youtube.com/watch?v=c3iEl5AwUF8
    {
        float extraHeight = 0.5f;
        Physics2D.queriesStartInColliders = false; // avoid detecting its own collider
        RaycastHit2D raycastHit = Physics2D.Raycast(coll.bounds.center, Vector2.down, coll.bounds.extents.y + extraHeight);
        return raycastHit.collider != null;
    }

    /* UNCOMMENT FOR ANIMATIONS
    //Animate the character
    private void Animate()
    {
        if (rb.velocity.x < 0f) // flip the sprite to point to the right direction
        {
            sprite.flipX = true;
            anim.SetBool("Walk", true); // change animator parameter so that the character is walking
            anim.SetBool("Idle", false); // and stops idling
        } else if (rb.velocity.x > 0f)
        {
            sprite.flipX = false;
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);
        } else
        {
            anim.SetBool("Walk", false); // change animator parameter so that the character stops walking
            anim.SetBool("Idle", true); // and starts idling
        }
    }
    */
}
