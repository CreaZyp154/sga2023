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
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rat qui se déplace horizontalement
        Vector2 movement = new Vector2(speed, _rigidbody.velocity.y);
        //permet de faire avancer l'ennemi en utilisant le rigidbody (gravité)
        _rigidbody.velocity = movement;
        //fait avancer l'objet, le *time... fait que l'objet n'avance pas trop vite
        //this.transform.position +=  * Time.deltaTime;
    }

    //faire avancer dans l'autre sens lors d'un collision avec un trigger?
    private void OnTriggerEnter2D(Collider2D other)
    {
        speed *= -1;
        //this.transform.position += Vector3.left * Time.deltaTime;
    }
}
