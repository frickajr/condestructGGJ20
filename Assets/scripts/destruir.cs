using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour {
    private Connect con;

    void Awake () {
        this.con = GameObject.Find ("WS").GetComponent<Connect> ();
    }
    // Start is called before the first frame update

    async void OnCollisionEnter2D (Collision2D other) {

        if (other.gameObject.tag == "fraco") {
            Destroy (other.gameObject);
        }
        if (other.gameObject.tag == "chao") {
            Vector3 vec = other.gameObject.transform.position;
            await this.con.Send ("destruir", "chao", vec.x, vec.y);
            Destroy (other.gameObject);
        }
        if (other.gameObject.tag == "forte") {
            other.gameObject.GetComponent<morte> ().vida--;
        }
        if (this) {
            Destroy (this.gameObject);
        }
    }
}