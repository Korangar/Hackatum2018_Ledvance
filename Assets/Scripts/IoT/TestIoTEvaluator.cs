using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestIoTEvaluator : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var sensors = 
            from s in IoTManager.sensors
            where s is TestIoTSensor
            select s as TestIoTSensor;
        
        foreach (var s in sensors)
        {
            if (s.RunTime > 3)
            {
                s.TimeReset();
                IoTManager.Broadcast(new IoTEvent
                {
                    from = s,
                    data = null,
                    what = "Three seconds passed."
                });
            }
        }
    }
}
