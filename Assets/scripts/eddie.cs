using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eddie : MonoBehaviour
{   public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
