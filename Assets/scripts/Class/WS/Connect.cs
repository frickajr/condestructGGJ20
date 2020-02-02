using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ninja.WebSockets;
using UnityEngine;

public class Connect : MonoBehaviour {
    public Boolean ativo = false;
    private string apiUrl = "ws://10.150.0.71:8080";
    private WebSocket webSocket = null;
    private ManipuleObject man;

    void Awake () {
        if (ativo)
            this.man = GetComponent<ManipuleObject> ();
    }

    async void Start () {
        if (ativo)
        {
            this.webSocket = await new WebSocketClientFactory ().ConnectAsync (new Uri (this.apiUrl));     
            await this.Receive ();
        }
    }

    public async Task Send (string type, string asset, float x, float y) {
        if (ativo)
        {
            var json = new TypeObject (this.man, type, asset, x, y, false).ToJson ();
            var buffer = new ArraySegment<byte> (Encoding.UTF8.GetBytes (json));
            await this.webSocket.SendAsync (buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            return;
        }
    }

    private async Task Receive () {
        if (ativo)
        {
            var buffer = new ArraySegment<byte> (new byte[1024]);
            while (true) {
                WebSocketReceiveResult result = await this.webSocket.ReceiveAsync (buffer, CancellationToken.None);
                switch (result.MessageType) {
                    case WebSocketMessageType.Close:
                        return;
                    case WebSocketMessageType.Text:
                    case WebSocketMessageType.Binary:
                        string json = Encoding.UTF8.GetString (buffer.Array, 0, result.Count);
                        var obj = Newtonsoft.Json.Linq.JObject.Parse (json);
                        TypeObject man = new TypeObject (this.man, (string) obj["type"], (string) obj["asset"], (float) obj["x"], (float) obj["y"], (bool) obj["fuiEu"]);
                        man.Run ();
                        break;
                }
            }
        }
    }
}