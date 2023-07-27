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
   // public playerHealth pHealth;
    public float damage;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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

        if (Life == 0)
        {
            //D�truit l'objet 2 seconde apr�s que life==0
            Destroy(this.gameObject, 2);
            speed = 0;
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

        if (other.gameObject.CompareTag("Player"))
        {
          //  pHealth.health -= damage;
        }
        
        //this.transform.position += Vector3.left * Time.deltaTime;
    }
}
