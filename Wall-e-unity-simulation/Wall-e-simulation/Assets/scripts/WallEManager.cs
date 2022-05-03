using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEManager : MonoBehaviour, WSClientDelegate
{
    public GameObject wallE;
    RemoteControlInputProvider remoteController;

    WSClient wsClient;

    Vector2 previousPostion;
    public float positionScale;

    // Start is called before the first frame update
    void Start()
    {
        Controller controller = wallE.GetComponent<Controller>();
        remoteController = new RemoteControlInputProvider();
        controller.inputProvider = remoteController;

        wsClient = new WSClient(this);
        wsClient.Connect();
    }

    public void OnMessage(string message)
    {
        MovementCommand mc = JsonUtility.FromJson<MovementCommand>(message);
        remoteController.HandleMovementCommand(mc);
    }

    public void SendData(MessageData data)
    {
        string dataJson = JsonUtility.ToJson(data);
        wsClient.SendMessage(dataJson);
    }
}
