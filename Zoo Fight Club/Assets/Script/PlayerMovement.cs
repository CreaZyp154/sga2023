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
    AudioSource soundEffect; 
    private SpriteRenderer sr;
    public Audioclips sounds;
    public float direction_Dash; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        soundEffect = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Jump");
            soundEffect.clip = sounds.Jump;
            soundEffect.Play(); 
          
     
            jumpTimeCounter = jumpTime;
        }
        if (Input.GetKey(KeyCode.W) && isJumping == true)
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
        if (Input.GetKeyUp(KeyCode.W))
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
            direction_Dash = Input.GetAxisRaw("Horizontal"); 

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
    
   
          
        
  

