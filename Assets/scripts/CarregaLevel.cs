﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class CarregaLevel : MonoBehaviour
{
    public GameObject tijolo;
    public GameObject coluna;
    public GameObject buraco;
    public GameObject agua;
    public GameObject bandeira;

    public int levelColumns = 10;
    public int levelRows = 7;

    public string levelDescriptorStr = string.Empty;
    public char[,] levelDescriptor;
    
    void Awake()
    {
        if (levelDescriptorStr.Length != (levelColumns * levelRows))
        {
            throw new Exception("Número de caracteres da string é incompatível com o tamanho da matriz!");
        }

        levelDescriptor = new char[levelRows, levelColumns];

        var linhas = DivideEmLinhas(levelDescriptorStr, levelColumns);

        int row = 0;
        foreach (var linha in linhas)
        {
            int col = 0;
            foreach (char symbol in linha)
            {
                levelDescriptor[row, col] = symbol;
                col++;
            }

            row++;
        }
        
        for (int y = 0; y < levelRows; y++)
        {
            for (int x = 0; x < levelColumns; x++)
            {
                if(levelDescriptor[y,x].Equals('T'))
                {
                    Instantiate(tijolo, new Vector3((float) x, (float) -y, 0f), Quaternion.identity);
                }

                if(levelDescriptor[y,x].Equals('C'))
                {
                    Instantiate(coluna, new Vector3((float) x, (float) -y, 0f), Quaternion.identity);
                }

                if(levelDescriptor[y,x].Equals('B'))
                {
                    Instantiate(bandeira, new Vector3((float) x, (float) -y, 0f), Quaternion.identity);
                }

                if(levelDescriptor[y,x].Equals('A'))
                {
                    Instantiate(agua, new Vector3((float) x, (float) -y, 0f), Quaternion.identity);
                }
            }
        }
    }

    /// <summary>
    /// Recebe uma string e o numero de caracteres em cada linha e faz o split da string
    /// </summary>
    /// <param name="simbolos">string a ser quebrada</param>
    /// <param name="numSimbolosPorLinha">numero de caracteres por linha</param>
    /// <returns>colecao de linhas</returns>
    static IEnumerable<string> DivideEmLinhas(string simbolos, int numSimbolosPorLinha)
    {
        return Enumerable.Range(0, simbolos.Length / numSimbolosPorLinha)
            .Select(i => simbolos.Substring(i * numSimbolosPorLinha, numSimbolosPorLinha));
    }
}
