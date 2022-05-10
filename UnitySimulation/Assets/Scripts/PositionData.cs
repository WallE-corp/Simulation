using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PositionData : IMessageData
{
    public int type = 1;
    public int Type { get { return type; } }
    public double x;
    public double y;
}
