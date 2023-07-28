using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ennemi1 : MonoBehaviour
{
    //met en place le rigidbody
    Rigidbody2D _rigidbody;
    //donne une vitesse
    public float speed = 2f;
    private SpriteRenderer sr;
    private int Life = 1;
   public playerHealth pHealth;
    public float damage;
    Animator anim;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        pHealth = FindAnyObjectByType<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rat qui se d�place horizontalement
        Vector2 movement = new Vector2(speed, _rigidbody.velocity.y);
        //permet de faire avancer l'ennemi en utilisant le rigidbody (gravit�)
        _rigidbody.velocity = movement;
        //fait avancer l'objet, le *time... fait que l'objet n'avance pas trop vite
        //this.transform.position +=  * Time.deltaTime;
        sr.flipX = movement.x > 0;

        if (Life <= 0)
        {
            //Détruit l'objet 2 seconde après que life==0
            anim.SetTrigger("RatDeath");
            _rigidbody.bodyType = RigidbodyType2D.Static;
            Destroy(GetComponent<BoxCollider2D>());

            speed = 0;
            
            Destroy(this, 2);

        }
    }

    //faire avancer dans l'autre sens lors d'un collision avec un trigger?
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("retour"))
        {
            speed *= -1;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            Life--;
        }

        
        //this.transform.position += Vector3.left * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth.Takehit(damage);

        }
    }
}
