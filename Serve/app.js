const WebSocket = require('ws');

const wss = new WebSocket.Server({ port: 8080 });

wss.on('connection', ws => {
  sendFase();

  ws.on('message', message => {
    console.log(message);
    broadcast(message);
  });
});

function broadcast(msg) {
  wss.clients.forEach((client) => {
    if (client.readyState === WebSocket.OPEN) {
      client.send(msg);
    }
  });
}

function sendFase() {
  // broadcast("{ type: 'mensagem', msg: 'Arquivo da fase'}");
}