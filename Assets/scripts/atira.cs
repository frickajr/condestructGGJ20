using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atira : MonoBehaviour
{   
    
    public GameObject objeto, tijolo;
    public Transform poti, potiFlip;

    SpriteRenderer m_SpriteRenderer;
    Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x")){

            //Debug.Log(potiFlip.position);

            
            //Debug.Log(posicao);


            if (m_SpriteRenderer.flipX) {
                Vector3 posicao = new Vector3 ( (int)potiFlip.position.x,
                                            (int)potiFlip.position.y,0);
                Instantiate(tijolo, posicao, potiFlip.rotation);
            }             
            else
            {
                Vector3 posicao = new Vector3 ( (int)poti.position.x,
                                            (int)poti.position.y,0);
                Instantiate(tijolo, posicao, potiFlip.rotation);
            }            
                
        }

        if (Input.GetKeyDown("z")){

            animator.SetTrigger("acao");

            if (m_SpriteRenderer.flipX) {
                GameObject clone;
                clone = Instantiate(objeto, potiFlip.position, potiFlip.rotation) as GameObject;
                clone.GetComponent<balin>().balinspeed *= -1;
            }             
            else            
                Instantiate(objeto, poti.position, potiFlip.rotation);
        }
    }
}
