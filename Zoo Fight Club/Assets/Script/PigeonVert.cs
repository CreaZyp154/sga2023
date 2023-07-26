using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonVert : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float speed = 2f;
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
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        speed *= -1;
        
    }
}
