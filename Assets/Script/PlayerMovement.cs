using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask JumpableGround;
    private float dirX = 0f;
   
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float JumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling}
    [SerializeField] private AudioSource JumpSoundEffect;


    private MovementState state = MovementState.idle;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // GetAxisRaw : khi muon dung nhan vat thi se dung han chu khong truot di mot doan nhu GetAxis  
        dirX = Input.GetAxisRaw("Horizontal");
        // velocity : vi tri
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        // getButtonDown 
        if (Input.GetButtonDown("Jump")  && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            JumpSoundEffect.Play();
        }
        UpdateAnimationUpdate();
        
    }
    private void UpdateAnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
            
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        
        anim.SetInteger("state", (int)state);
    }
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }
/*    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Trap")
        {
            rb.transform.position = CheckPoint.GetActiveCheckPointPosition();
        }
    }*/
}
