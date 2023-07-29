using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonDiagleft : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float speed = 1f;
    Vector3 direction = new Vector3 (-1, 1, 0);
    private int Life = 3;
    public playerHealth pHealth;
    public float damage;
    private SpriteRenderer sr;
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        pHealth = FindAnyObjectByType<playerHealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = direction * speed;

        if (Life <= 0)
        {
            //Détruit l'objet 2 seconde après que life==0
            anim.SetTrigger("Death");
            Destroy(this.gameObject, 2);
            speed = 0;
        }

        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-2, transform.localScale.y, 0);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(2, transform.localScale.y, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        direction *= -1;

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
