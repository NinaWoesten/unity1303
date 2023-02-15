using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer flip;
    private Animator anim;
    private float inputX;
    private enum MovementThing {idle, walk, Jumping, Falling}
    private BoxCollider2D collider;
    [SerializeField] private LayerMask jumpGround;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        flip = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputX * 7f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }
        UpdateAnimation();

    }
    private void UpdateAnimation()
    {
        MovementThing state;
        if (inputX > 0f)
        {
            state = MovementThing.walk;
            flip.flipX = false;
            
        }
        else if(inputX < 0f)
        {
            state = MovementThing.walk;
            flip.flipX = true;
        }
        else
        {
            state = MovementThing.idle;
        }
        if(rb.velocity.y > .1f)
        {
            state = MovementThing.Jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementThing.Falling;
        }
        anim.SetInteger("state", (int)state);
    }
    private bool Grounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpGround);//Es wird eine Box um den Spieler erstellt. Vector bringt die Box einwenig nach unten
    }
  
}
