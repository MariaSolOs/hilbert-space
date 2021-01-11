using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hilbert : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float walkingSpeed = 3f;

    private Rigidbody2D rigidBody = default;
    private Animator animator = default;
    private GameObject body = default;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        body = transform.Find("Body").gameObject;
    }

    private void Update()
    {
        Walk();
        FlipSprite();
    }

    private bool IsHilbertMovingHorizontally() 
    {
        return Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
    }

    private void Walk()
    {
        float controlInput = Input.GetAxis("Horizontal");
        Vector2 hilbertVelocity = new Vector2(controlInput * walkingSpeed, rigidBody.velocity.y);
        rigidBody.velocity = hilbertVelocity;

        animator.SetBool("isWalking", IsHilbertMovingHorizontally());
    }

    private void FlipSprite()
    {
        if( IsHilbertMovingHorizontally() )
        {
            bool flipSprite = Mathf.Sign(rigidBody.velocity.x) == -1;  
            body.GetComponent<SpriteRenderer>().flipX = flipSprite;
        }
    }

    public void TriggerLoseAnimation()
    {
        animator.SetTrigger("loseTrigger");
    }

    public void TriggerWinAnimation()
    {
        animator.SetTrigger("winTrigger");
    }
}
