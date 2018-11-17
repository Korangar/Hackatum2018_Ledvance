using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIoTSensor : IoTSensor
{
    private float start;
    public float RunTime => Time.time-start;
    
    public void TimeReset()
    {
        start = Time.time;
    }
    
    public void TimeReset(float f)
    {
        start = f;
    }
}
