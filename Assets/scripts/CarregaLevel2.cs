using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class CarregaLevel2 : MonoBehaviour
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

    public Hashtable Objetos = new Hashtable();

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
                GameObject temp = null;
                ObjetosEmTela novoObjeto = new ObjetosEmTela();

                switch (levelDescriptor[y, x])
                {
                    case 'T':
                        temp = this.tijolo;
                        novoObjeto.tipo = "tijolo";
                        break;
                    case 'C':
                        temp = this.coluna;
                        novoObjeto.tipo = "coluna";
                        break;
                    case 'B':
                        temp = this.bandeira;
                        novoObjeto.tipo = "bandeira";
                        break;
                    case 'A':
                        temp = this.agua;
                        novoObjeto.tipo = "agua";
                        break;
                    default:
                        break;
                }

                if (temp == null)
                {
                    continue;
                }

													  
				 
                var teste = Instantiate(temp, new Vector3((float)x, (float)-y, 0f), Quaternion.identity);
                novoObjeto.x = x;
                novoObjeto.y = -y;
                Objetos.Add(teste.GetInstanceID(),Newtonsoft.Json.JsonConvert.SerializeObject(novoObjeto));

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

    
    public class ObjetosEmTela
    {
        public int x { get; set;}
        public int y { get; set; }
        public string tipo { get; set; }
    }
}

