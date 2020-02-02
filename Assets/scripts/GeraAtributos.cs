using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeraAtributos : MonoBehaviour
{
    public static int construir;
    public static int destruir;
    public static GameObject Placar;

    // Start is called before the first frame update
    void Awake()
    {
        var geraAleatorio = new System.Random();
        var aleatorio = geraAleatorio.Next(0, 10);

        construir = aleatorio;
        destruir = 10 - construir;
    }

    public static void Construir()
    {
        construir--;
        destruir++;
    }

    public static void Destruir()
    {
        construir++;
        destruir--;
    }

    public static bool PodeConstruir()
    {
        return construir > 0;
    }

    public static int GetDestruir()
    {
        return destruir;
    }

    public static int GetConstruir()
    {
        return construir;
    }

    public static bool PodeDestruir()
    {
        return destruir > 0;
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.black;
        GUI.Label(new Rect(530, 180, 100, 20), $"Z: {GetDestruir()} | X: {GetConstruir()} ",style);
    }

}
