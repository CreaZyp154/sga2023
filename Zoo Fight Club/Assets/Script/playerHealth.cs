using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class playerHealth : MonoBehaviour
{
    public float health; 
    public float maxHealth;
    public Image healthbar;
    public Rigidbody2D rb; 
    Animator anim;
    bool isdead = false;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !isdead){
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; 
            anim.SetTrigger("die");
            Destroy(GetComponent<PlayerAttack>());
            Destroy(GetComponent<PlayerMovement>());
            Destroy(this.gameObject, 2f);
            isdead = true; 
        }
      

        healthbar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
    public void Takehit(float damage)
    {
        health -= damage;
        if (health >= 1) {
            Debug.Log("damage animation");
            anim.SetTrigger("damage"); 
        }
    }
}
