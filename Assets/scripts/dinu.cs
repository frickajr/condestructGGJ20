using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dinu : MonoBehaviour
{    public Rigidbody2D rb;
     private bool nochao;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(4* Input.GetAxis("Horizontal"), rb.velocity.y);
        if(Input.GetKeyDown("space") && nochao){
            rb.AddForce(Vector3.up * 350);
            nochao = false;
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "chao"){
            nochao = true;
        }
    }
}
