using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class OBstacleEventCommand : IMessageData
{
    public int type = 6;
    public int Type { get { return type; } }
    public string imagePath;
}
