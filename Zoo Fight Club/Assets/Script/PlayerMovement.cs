using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    public float Move;
    public float direction_attack;
    public Rigidbody2D rb;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    public float jumpforce;
    Animator anim;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
          
     
            jumpTimeCounter = jumpTime;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            // Fin de long jump

        }


        if (GetComponent<PlayerAttack>().isDashing)
        {
            return;
        }
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            direction_attack = Input.GetAxisRaw("Horizontal");

        }
        Move = Input.GetAxis("Horizontal");


        rb.velocity = new Vector2(speed * Move, rb.velocity.y);
        sr.flipX = rb.velocity.x < 0;
        anim.SetInteger("velocit", (int)rb.velocity.x*10);







    }

    public void Landing()
    {
        isJumping = false;
    }
    public void Jump()
    {
        isJumping = true;
        rb.velocity = Vector2.up * jumpforce;
    }
}
    
   
          
        
  

