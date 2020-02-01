using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarregaLevel : MonoBehaviour
{
    public GameObject tijolo;

    const int LEVEL_COLUMNS = 3;
    const int LEVEL_ROWS = 3;

    // public string levelDescriptorStr = "   \n   \nTTT\n";
    public char[][] levelDescriptor = new char[][]{ new char[]{'T', ' ', ' '}, new char[]{' ', ' ', ' '}, new char[]{'T', 'T', 'T'}};
    void Awake()
    {
        Debug.Log("Hello World!");
        // Instantiate(tijolo, new Vector3(1f, 1f, 0f), Quaternion.identity);
        for (int y = 0; y < LEVEL_ROWS; y++)
        {
            for (int x = 0; x < LEVEL_COLUMNS; x++)
            {
                if(levelDescriptor[y][x].Equals('T'))
                {
                    Instantiate(tijolo, new Vector3((float) x, (float) -y, 0f), Quaternion.identity);
                }
            }
        }
    }
}
