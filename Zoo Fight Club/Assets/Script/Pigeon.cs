using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float speed = 2f;
    private int Life = 1;
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
        //this.transform.position += Vector3.left * Time.deltaTime;
        if (other.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            Life--;
        }
    }
}
