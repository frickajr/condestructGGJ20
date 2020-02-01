using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atira : MonoBehaviour
{   public GameObject objeto;
    public Transform poti;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z")){
            Instantiate(objeto, poti.position, Quaternion.identity);

        }
    }
}
