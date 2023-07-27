using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatDash : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float speed = 2f;
    public float TimetoDash=3;
    private float CounterTime;
    public float DashForce = 5f;
    int State = 0;
    private int Life = 3;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(speed, _rigidbody.velocity.y);
        //permet de faire avancer l'ennemi en utilisant le rigidbody (gravité)
        _rigidbody.velocity = movement;
        CounterTime += Time.deltaTime;
        


        if (CounterTime >= TimetoDash && State == 0)
        {
            speed *= 2.5f;
            CounterTime = 0;
            State = 1;
        }

        if (State == 1 && CounterTime >= 1)
        {
            speed /= 2.5f;
            CounterTime = 0;
            State = 0;
        }

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
        DashForce *= -1;

        if (other.gameObject.layer == LayerMask.NameToLayer("Attack"))
        {
            Life--;
        }
    }
}
