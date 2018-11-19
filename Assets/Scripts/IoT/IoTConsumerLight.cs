using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoTConsumerLight : IoTConsumer
{
    public override bool IsEventMatch(IoTEvent e)
    {
        return false;
    }

    public override void Consume(IoTEvent e)
    {
        throw new System.NotImplementedException();
    }
}
