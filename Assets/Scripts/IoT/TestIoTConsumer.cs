using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIoTConsumer : IoTConsumer
{
    
    
    public override bool IsEventMatch(IoTEvent e)
    {
        return e.from is TestIoTSensor;
    }

    public override void Consume(IoTEvent e)
    {
        Debug.Log("Consumed Test Event");
    }
}
