﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balin : MonoBehaviour
{   private Rigidbody2D rb;
    public float balinspeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(balinspeed,rb.velocity.y);
        //rb.velocity = Vector2.left * balinspeed;
    }
}
