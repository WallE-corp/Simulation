using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PositionData : MessageData
{
    int type = 1;
    public double x;
    public double y;
}
