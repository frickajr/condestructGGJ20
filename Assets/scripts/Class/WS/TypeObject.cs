using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ninja.WebSockets;
using UnityEngine;

public class TypeObject {

  public ManipuleObject man;
  public string type = "";
  public string asset = "";
  public float x = 0.0F;
  public float y = 0.0F;

  public TypeObject (ManipuleObject man, string type, string asset, float x, float y) {
    this.man = man;
    this.type = type;
    this.asset = asset;
    this.x = x;
    this.y = y;
  }

  public string ToJson () {
    return $"{{ type: '{this.type}', asset: '{this.asset}', x: '{this.x}', y: '{this.y}' }}";
  }

  public void Run () {
    switch (this.type) {
      case "criar":
        this.man.InstanceObject (this);
        break;
      case "destruir":
        this.man.DestroiObject (this);
        break;
      default:
        Debug.Log ("Não implementado");
        break;
    }
  }
}