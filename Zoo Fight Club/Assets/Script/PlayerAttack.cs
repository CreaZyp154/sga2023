using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    private bool canDash = true;
public bool isDashing;
private float dashingPower = 24f;
private float dashingTime = 0.2f;
private float dashingCooldown = 1f;
    public float dashSpeed; 
[SerializeField] private TrailRenderer tr;
    public Rigidbody2D rb;
    [SerializeField] GameObject prefab_attack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash()); 

        }
        if (Input.GetKeyDown(KeyCode.J)) {
            GameObject attack = Instantiate(prefab_attack, transform.position + new Vector3(2.5f * GetComponent<PlayerMovement>().direction_attack, -0.5f, 0), Quaternion.identity);
            Destroy(attack, 0.2f);
        }
    



    }
    private IEnumerator Dash()
    {
        rb.velocity = new Vector2(dashSpeed * GetComponent<PlayerMovement>().Move, 0);
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        //rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
     //   rb.velocity = 0
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        
    }
}
