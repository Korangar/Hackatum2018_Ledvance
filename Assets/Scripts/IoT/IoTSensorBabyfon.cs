using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IoTSensorBabyfon : IoTSensor
{
    public void Trigger()
    {
        IoTManager.Broadcast(new IoTEvent {
            from = this,
            data = 1,
            what = "Audio threshold exceeded!"
        });
    }
}
