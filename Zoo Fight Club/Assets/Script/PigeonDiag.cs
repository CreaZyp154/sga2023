using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonDiag : MonoBehaviour
{
    //Pigeon qui va en diagonale droite
    Rigidbody2D _rigidbody;
    public float speed = 1f;
    Vector3 direction = new Vector3(1, 1, 0);
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        direction *= -1;
    }
}
