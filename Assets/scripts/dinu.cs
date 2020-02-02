using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinu : MonoBehaviour
{    Rigidbody2D rb;
     private bool nochao;
     Animator anim;
     SpriteRenderer m_SpriteRenderer;
     private Connect con;

    // Start is called before the first frame update
    void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        this.con = GameObject.Find("WS").GetComponent<Connect> ();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(4* Input.GetAxis("Horizontal"), rb.velocity.y);
        if(Input.GetKeyDown("space") && nochao){
            rb.AddForce(Vector3.up * 350);
            nochao = false;
            anim.SetBool("pulo", true);
        }
        if (Input.GetAxis("Horizontal") !=0 ){
            anim.SetBool("walk", true);
            if (Input.GetAxis("Horizontal")>0)
                m_SpriteRenderer.flipX = false;
            else
                m_SpriteRenderer.flipX = true;

        }else{
            anim.SetBool("walk",false);
        }
         
    }   
   
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "chao"){
            nochao = true;
            anim.SetBool("pulo", false);
        }
    }

    async void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "ganhei"){
            Debug.Log("ganhei");
            if (this.con.ativo)
                await this.con.Send ("ganhei","",0,0);
        }
    }
}
