using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenItens : MonoBehaviour
{
    public Hashtable Objetos = null;     

    public static ScreenItens instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Objetos = new Hashtable();
        }
    }

    public void Add(int i,string objeto)
    {
        Objetos.Add(i,objeto);
    }

    public void Remove(int i)
    {
        Objetos.Remove(i);
    }

    public int Count()
    {
        return Objetos.Count;
    }
}
