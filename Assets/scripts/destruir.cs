using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{   
    // Start is called before the first frame update
    
    void OnCollisionEnter2D(Collision2D other){

        
        if(other.gameObject.tag == "fraco"){
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "chao"){
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "forte"){
            other.gameObject.GetComponent<morte>().vida --;
        }
        Destroy(gameObject);
    }
}
