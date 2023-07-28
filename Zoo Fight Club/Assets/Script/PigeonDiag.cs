using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonDiag : MonoBehaviour
{
    //Pigeon qui va en diagonale droite
    Rigidbody2D _rigidbody;
    public float speed = 1f;
    Vector3 direction = new Vector3(1, 1, 0);
    private int Life = 3;
    public playerHealth pHealth;
    public float damage;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        pHealth = FindAnyObjectByType<playerHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = direction * speed;

        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-2, transform.localScale.y, 0);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(2, transform.localScale.y, 0);
        }

        if (Life == 0)
        {
            //D�truit l'objet 2 seconde apr�s que life==0
            Destroy(this.gameObject, 2);
            speed = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        direction *= -1;

        if (other.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            Life--;
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
