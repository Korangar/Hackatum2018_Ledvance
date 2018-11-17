using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class IoTConsumer : SerializedMonoBehaviour
{
    private void OnEnable()
    {
        IoTManager.Add(this);
    }

    private void OnDisable()
    {
        IoTManager.Remove(this);
    }

    public abstract bool IsEventMatch(IoTEvent e);
    public abstract void Consume(IoTEvent e);
}
