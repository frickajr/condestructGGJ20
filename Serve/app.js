const WebSocket = require('ws');

const wss = new WebSocket.Server({ port: 8080 });

wss.on('connection', ws => {
  sendFase();

  ws.on('message', message => {
    console.log(message);
    broadcast(ws, message);
  });
});

function broadcast(ws,  msg) {
  let objMsg = JSON.parse(msg);

  wss.clients.forEach((client) => {
    if (client == ws) {
      objMsg.fuiEu = true;
    } else {
      objMsg.fuiEu = false;
    }
    if (client.readyState === WebSocket.OPEN) {
      client.send(JSON.stringify(objMsg));
    }
  });
}

function sendFase() {
  // broadcast("{ type: 'mensagem', msg: 'Arquivo da fase'}");
}