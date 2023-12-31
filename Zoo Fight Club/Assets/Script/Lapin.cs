using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lapin : MonoBehaviour
{
    public float TimetoJump;
    private float CounterTime;
    public float JumpForce = 50;
    Rigidbody2D _rigidbody;
    private int CanJump;
    private float speed = 2f;
    private int Life = 2;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        //Provisoir
        //CanJump = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(speed, _rigidbody.velocity.y);
        _rigidbody.velocity = movement;

        if (CanJump == 1)
        {
            CounterTime += Time.deltaTime;


            if (CounterTime >= TimetoJump)
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce));
                CounterTime = 0;
                CanJump = 0;
            }
        }

        if (Life == 0)
        {
            //D�truit l'objet 2 seconde apr�s que life==0
            Destroy(this.gameObject, 2);
            speed = 0;
            CanJump = 0;
        }
    }

    
   private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            CanJump = 1;
        }
        
        if (other.gameObject.layer == LayerMask.NameToLayer("retour"))
        {
            speed *= -1;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            Life--;
        }
    }
}
