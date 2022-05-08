using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPostionDataEvent : UnityEvent<PositionData> { }

public class PositionDataHandler : MonoBehaviour
{
    [Range(0f, 2f)]
    public float positionScale;
    [Range(0, 10)]
    public int positionRoundDecimals = 3;

    [SerializeField] public OnPostionDataEvent onPositionData;
    private Vector2 previousPostion;

    void Awake() {
        onPositionData = new OnPostionDataEvent();
    }

    void Start()
    {
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
        previousPostion = postion;
        onPositionData.Invoke(data);
    }
}
