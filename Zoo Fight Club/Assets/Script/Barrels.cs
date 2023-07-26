using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi2 : MonoBehaviour
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
        //Mettre mieux gravité pour que l objet roule
       // Vector2 movement = new Vector2(speed, _rigidbody.velocity.y);
        //_rigidbody.velocity = movement;
    }
}
