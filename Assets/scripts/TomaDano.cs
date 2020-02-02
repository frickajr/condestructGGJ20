using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomaDano : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "perigo")
        {
            Debug.Log("Ai aiiiiiiiii");
        }
    }
}
