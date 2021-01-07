using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hilbert : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float walkingSpeed = 1f;

    private Rigidbody2D rigidBody = default;
    private Animator animator = default;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
        FlipSprite();
    }

    private bool IsPlayerMovingHorizontally() 
    {
        return Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
    }

    private void Walk()
    {
        float controlInput = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlInput * walkingSpeed, rigidBody.velocity.y);
        rigidBody.velocity = playerVelocity;

        animator.SetBool("isWalking", IsPlayerMovingHorizontally());
    }

    private void FlipSprite()
    {
        if( IsPlayerMovingHorizontally() )
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        }
    }
}
