using WebSocketSharp;
using UnityEngine;

public interface WSClientDelegate
{
    void OnMessage(string message);
}

public class WSClient
{
    WebSocket ws;
    WSClientDelegate messageDeletage;

    public WSClient(WSClientDelegate _deletegate)
    {
        messageDeletage = _deletegate;
    }

    public void Connect()
    {
        ws = new WebSocket("ws://localhost:8765");
        ws.OnMessage += OnMessage;
        ws.OnOpen += OnOpen;
        ws.Connect();
    }

    public void SendMessage(string message)
    {
        if (ws == null || !ws.IsAlive) return;
        ws.Send(message);
    }

    public void OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log("Connected");
    }

    public void OnMessage(object sender, MessageEventArgs e)
    {
        messageDeletage.OnMessage(e.Data);
    }
}
