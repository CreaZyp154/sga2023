using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonVert : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float speed = 2f;
    private int Life = 2;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(_rigidbody.velocity.x, speed);
        _rigidbody.velocity = movement;

        if (Life == 0)
        {
            //D�truit l'objet 2 seconde apr�s que life==0
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
}
