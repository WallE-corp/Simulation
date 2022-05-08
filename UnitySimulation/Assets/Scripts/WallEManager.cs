using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEManager : MonoBehaviour, WSClientDelegate
{
    public GameObject wallE;
    RemoteControlInputProvider remoteController;

    WSClient wsClient;

    // Start is called before the first frame update
    void Start()
    {
        WallEController controller = wallE.GetComponent<WallEController>();
        remoteController = new RemoteControlInputProvider();
        controller.inputProvider = remoteController;

        PositionDataHandler posDataHandler = wallE.GetComponent<PositionDataHandler>();
        posDataHandler.onPositionData.AddListener(SendData);

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
        Debug.Log(dataJson);
        //wsClient.SendMessage(dataJson);
    }
}
