using System;
using UnityEngine;

[Serializable]
public class IoTEvent
{
    public IoTSensor from;
    public string what;
    public object data;
}