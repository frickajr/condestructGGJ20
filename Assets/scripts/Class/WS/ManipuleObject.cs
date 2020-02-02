using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ninja.WebSockets;
using UnityEngine;

public class ManipuleObject : MonoBehaviour {

  public GameObject tijolo, perdeu;

  GameObject camera;

  void Awake()
  {
    camera = GameObject.Find("Main Camera");
  }

  public void InstanceObject (TypeObject tp) {
    switch (tp.asset) {
      case "tijolo":
        var objCreated = Instantiate (this.tijolo, new Vector3 (tp.x, tp.y, 0f), Quaternion.identity);
        // Add objeCreated in Hash Table
        break;
      default:
        Debug.Log ("Não implementado");
        break;
    }
  }

  public void DestroiObject (TypeObject tp) {
    GameObject[] allObjects = GameObject.FindGameObjectsWithTag(tp.asset);

    foreach (GameObject go in allObjects) {
      if ((int) go.transform.position.x == (int) tp.x && (int) go.transform.position.y == (int) tp.y) {
        Destroy(go);
        return;
      }
    }
  }

  public void ShowMensagem (TypeObject tp) {
    if (tp.type == "ganhei" && tp.fuiEu == false) {
      Debug.Log("Perdi :(");
      Instantiate(perdeu, new Vector3(camera.transform.position.x,
                                            camera.transform.position.y, 0), transform.rotation);
      Time.timeScale = 0f;
    }
  }
}