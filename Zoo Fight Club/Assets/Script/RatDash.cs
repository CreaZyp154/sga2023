using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDash : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float speed = 2f;
    public float TimetoDash=3;
    private float CounterTime;
    public float DashForce = 5f;
    int State = 0;
    private int Life = 3;
    public playerHealth pHealth;
    public float damage;
    private SpriteRenderer sr;
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pHealth = FindAnyObjectByType<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(speed, _rigidbody.velocity.y);
        //permet de faire avancer l'ennemi en utilisant le rigidbody (gravit�)
        _rigidbody.velocity = movement;
        CounterTime += Time.deltaTime;
        //sr.flipX = movement.x > 0;
        if(movement.x > 0)
        {
            transform.localScale = new Vector3(-2, transform.localScale.y, 0);
        }else if(movement.x < 0)
        {
            transform.localScale = new Vector3(2, transform.localScale.y, 0);
        }



        if (CounterTime >= TimetoDash && State == 0)
        {
            speed *= 2.5f;
            CounterTime = 0;
            State = 1;
        }

        if (State == 1 && CounterTime >= 1)
        {
            speed /= 2.5f;
            CounterTime = 0;
            State = 0;
        }

        if (Life <= 0)
        {
            //D�truit l'objet 2 seconde apr�s que life==0
            anim.SetTrigger("RatDeath");
            _rigidbody.bodyType = RigidbodyType2D.Static;
            Destroy(GetComponent<BoxCollider2D>());

            speed = 0;
            
            Destroy(this, 2);

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        speed *= -1;
        DashForce *= -1;

        if (other.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            Life--;
            anim.SetTrigger("Deg");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth.Takehit(damage);

        }
    }
}
