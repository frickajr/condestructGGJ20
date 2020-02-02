using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atira : MonoBehaviour
{
    private Connect con;

    public GameObject objeto, tijolo;
    public Transform poti, potiFlip;

    SpriteRenderer m_SpriteRenderer;
    Animator animator;

    void Awake()
    {

        this.con = GameObject.Find("WS").GetComponent<Connect>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (this.con.ativo)
                await this.con.Send("ganhei", "", 0, 0);
        }

        if (Input.GetKeyDown("x"))
        {

            if (GeraAtributos.PodeConstruir())
            {

                GeraAtributos.Construir();

                if (m_SpriteRenderer.flipX)
                {
                    Vector3 posicao = new Vector3((int)potiFlip.position.x, (int)potiFlip.position.y, 0);
                    if (this.con.ativo)
                        await this.con.Send("criar", "tijolo", posicao.x, posicao.y);
                    else
                        Instantiate(tijolo, posicao, potiFlip.rotation);
                }
                else
                {
                    Vector3 posicao = new Vector3((int)poti.position.x, (int)poti.position.y, 0);
                    if (this.con.ativo)
                        await this.con.Send("criar", "tijolo", posicao.x, posicao.y);
                    else
                        Instantiate(tijolo, posicao, potiFlip.rotation);
                }

            }
        }

        if (Input.GetKeyDown("z"))
        {
            if (GeraAtributos.PodeDestruir())
            {
                GeraAtributos.Destruir();

                animator.SetTrigger("acao");

                if (m_SpriteRenderer.flipX)
                {
                    GameObject clone;
                    clone = Instantiate(objeto, potiFlip.position, potiFlip.rotation) as GameObject;
                    clone.GetComponent<balin>().balinspeed *= -1;
                }
                else
                    Instantiate(objeto, poti.position, potiFlip.rotation);
            }
        }
    }
}
