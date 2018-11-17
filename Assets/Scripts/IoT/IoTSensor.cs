using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class IoTSensor : SerializedMonoBehaviour
{
    private void OnEnable()
    {
        IoTManager.Add(this);
    }

    private void OnDisable()
    {
        IoTManager.Remove(this);
    }
}
