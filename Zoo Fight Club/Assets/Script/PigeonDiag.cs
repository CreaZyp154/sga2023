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
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = direction * speed;

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
}
