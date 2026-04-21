using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class playercontrol2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 8f;

    private enum MovementState { idle, run, jump, fall }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal2");
        rb.linearVelocity = new Vector2(dirX * moveSpeed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump2") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state2 = MovementState.idle;
        if (dirX > 0.1f)
        {
            state2 = MovementState.run;
            sprite.flipX = false;
        }
        else if (dirX < -0.1f)
        {
            state2 = MovementState.run;
            sprite.flipX = true;
        }
        if (rb.linearVelocity.y > .1f)
        {
            state2 = MovementState.jump;
        }

        else if (rb.linearVelocity.y < -.1f)
        {
            state2 = MovementState.fall;
        }

        anim.SetInteger("state2", (int)state2);
        anim.SetFloat("absDirX", Mathf.Abs(dirX));


    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
  
}