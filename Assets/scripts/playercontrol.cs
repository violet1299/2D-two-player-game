using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private enum MovementState { idle,running,jumping,falling}
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(dirX*moveSpeed, rb.linearVelocity.y);

        if(Input.GetButtonDown("Jump")&&IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state = MovementState.idle;
        if (dirX > 0f)
        {
           state =MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        if( rb.linearVelocity.y>.1f)
        {
            state = MovementState.jumping;
        }

        else if(rb.linearVelocity.y <-.1f)
        {
            state = MovementState.falling;

        }
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    { 
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    
   
}
