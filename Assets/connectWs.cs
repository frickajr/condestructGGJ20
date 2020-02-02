using Ninja.WebSockets;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

public class connectWs : MonoBehaviour
{
    GameObject instance = null;
    private WebSocket webSocket = null;
    public GameObject tijolo;

    async void Start()
    {
        this.webSocket = await new WebSocketClientFactory().ConnectAsync(new Uri("ws://localhost:8080"));
        // await this.Send(new Property(0, 0, "tijolo"));
        instance = (GameObject) Instantiate(this.tijolo, new Vector3((float) 0.0, (float) 0.0, 0f), Quaternion.identity);
        await this.Receive();
    }

    void Update()
    {

    }
    
    // private async Task Send(Property prop)
    // {
    //     var json = Newtonsoft.Json.JsonConvert.SerializeObject(prop);
    //     // Debug.Log(json);
    //     var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(json));
    //     await this.webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
    //     return;
    // }

    private async Task Receive()
    {
        var buffer = new ArraySegment<byte>(new byte[1024]);
        while (true)
        {
            WebSocketReceiveResult result = await this.webSocket.ReceiveAsync(buffer, CancellationToken.None);
            switch (result.MessageType)
            {
                case WebSocketMessageType.Close:
                    return;
                case WebSocketMessageType.Text:
                case WebSocketMessageType.Binary:
                    string json = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    Debug.Log(json);
                    this.InstanceObjec(json);
                    break;
            }
        }
    }

    private void InstanceObjec(string json)
    {
        var prop = Newtonsoft.Json.Linq.JObject.Parse(json);
        switch ((string) prop["type"]) {
            case "mensagem":
                // Debug.Log((string) prop["msg"]);
                break;
            case "tijolo":
                Debug.Log(json);
                instance = (GameObject) Instantiate(this.tijolo, new Vector3((float) prop["x"], (float) prop["y"], 0f), Quaternion.identity);
                break;
        }
    }

    public void Msgenv() {
        Debug.Log("Foi!");
    }
}