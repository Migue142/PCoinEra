using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1 : MonoBehaviour
{

    public float FuerzaM = 0.1f;
    public int FuersaSalto = 5;
    public bool enSuelo = false;

    public Animator animator;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


// Santiago Llanos
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(new Vector2(0, FuersaSalto),ForceMode2D.Impulse);            
        }      


    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
           transform.position = transform.position + new Vector3 (-FuerzaM, 0, 0);
           transform.localScale = new Vector3 (-1, 1, 1);
           animator.SetBool("isRun",true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
           transform.position = transform.position + new Vector3 (FuerzaM, 0, 0);
           transform.localScale = new Vector3 (1, 1, 1);
           animator.SetBool("isRun",true);
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isRun",false);
        }

        if (rb.linearVelocity.y > 0)
        {
            animator.SetInteger("isJump", 1);
        }
        else if (rb.linearVelocity.y < 0)
        {
            animator.SetInteger("isJump", -1);
        }
        else
        {
            animator.SetInteger("isJump", 0);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        enSuelo = true;
        print("Colisiono con algo");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        enSuelo = false;
        print("No està colisionando");
    }
}
