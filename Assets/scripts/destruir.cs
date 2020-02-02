using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{   
    // Start is called before the first frame update

    public GameObject Objetos;
    
    void OnCollisionEnter2D(Collision2D other){

        if (ScreenItens.instance == null)
        {
            Instantiate(Objetos);
        }
        
        if(other.gameObject.tag == "fraco")
        {
            ScreenItens.instance.Objetos.Remove(other.gameObject.GetInstanceID());
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "chao"){
            ScreenItens.instance.Objetos.Remove(other.gameObject.GetInstanceID());
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "forte"){
            other.gameObject.GetComponent<morte>().vida --;
        }
        ScreenItens.instance.Objetos.Remove(gameObject.GetInstanceID());
        Destroy(gameObject);

    }
}
