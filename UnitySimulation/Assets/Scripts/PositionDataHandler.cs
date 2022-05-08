using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDataHandler : MonoBehaviour
{
    [Range(0f, 2f)]
    public float positionScale;
    [Range(0, 10)]
    public int positionRoundDecimals = 3;

    Vector2 previousPostion;
    // private WallEManager wallEManager;
    // private GameObject wallE;

    // Start is called before the first frame update
    void Start()
    {
        // wallEManager = GetComponent<WallEManager>();
        // wallE = wallEManager.wallE;
        previousPostion = new Vector2(transform.position.x * positionScale, transform.position.z * positionScale);
        StartCoroutine("SendPositionDataWithDelay", 1f);
    }

    IEnumerator SendPositionDataWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            SendPositionData();
        }
    }

    void SendPositionData()
    {
        Vector2 postion = new Vector2(transform.position.x * positionScale, transform.position.z * positionScale);
        Vector2 relativePostion = postion - previousPostion;
        
        PositionData data = new PositionData
        {
            x = System.Math.Round((double)relativePostion.x, positionRoundDecimals, System.MidpointRounding.AwayFromZero),
            y = System.Math.Round((double)relativePostion.y, positionRoundDecimals, System.MidpointRounding.AwayFromZero),
        };
        // wallEManager.SendData(data);

        previousPostion = postion;
    }
}
