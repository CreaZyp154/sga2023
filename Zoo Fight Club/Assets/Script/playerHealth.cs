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
    public GameController gameController;
   // OpenSceneMode openScene;
    AudioSource soundEffect;
    public Audioclips sounds; 
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        anim = GetComponent<Animator>();
        soundEffect = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !isdead){
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static; 
            anim.SetTrigger("die");
            Destroy(GetComponent<PlayerAttack>());
            Destroy(GetComponent<PlayerMovement>());
            soundEffect.clip = sounds.Death;
            soundEffect.Play();
            StartCoroutine(DeadPlayer()); 
           // Destroy(this.gameObject, 2f);
            isdead = true; 
        }
      

        healthbar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }
    IEnumerator DeadPlayer()
    {
        yield return new WaitForSeconds(2f);
        gameController.DeadPlayer();
    }
    public void Takehit(float damage)
    {
        health -= damage;
        if (health >= 1) {
            Debug.Log("damage animation");
            anim.SetTrigger("damage");
            soundEffect.clip = sounds.Death;
            soundEffect.Play(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.layer == LayerMask.NameToLayer("Win"))
        {
            gameController.Win();
        }
    }
}
