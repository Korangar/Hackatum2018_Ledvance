using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoTConsumerTVLivingRoom : IoTConsumer
{   
    public override bool IsEventMatch(IoTEvent e)
    {
        if (e.from is IoTSensorBabyfon) return true;
        return false;
    }

    public override void Consume(IoTEvent e)
    {   
    }
}
