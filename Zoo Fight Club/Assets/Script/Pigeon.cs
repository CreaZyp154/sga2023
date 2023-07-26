using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
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
        //Ce pigeon vol horizontalement (comme le rat sauf qu'il ne subit pas la gravité)
        Vector2 movement = new Vector2(speed, _rigidbody.velocity.y);
        _rigidbody.velocity = movement;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        speed *= -1;
        //this.transform.position += Vector3.left * Time.deltaTime;
    }
}
