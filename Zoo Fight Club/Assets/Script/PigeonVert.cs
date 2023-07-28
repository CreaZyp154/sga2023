using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonVert : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float speed = 2f;
    private int Life = 2;
    public playerHealth pHealth;
    public float damage;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        pHealth = FindAnyObjectByType<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(_rigidbody.velocity.x, speed);
        _rigidbody.velocity = movement;

        if (Life == 0)
        {
            //Détruit l'objet 2 seconde après que life==0
            Destroy(this.gameObject, 2);
            speed = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        speed *= -1;

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
