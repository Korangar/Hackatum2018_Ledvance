using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class IoTConsumer : IoTPlayerBase
{
    public abstract bool IsEventMatch(IoTEvent e);
    
    public void DoConsume(IoTEvent e)
    {
        var a = GetComponentInChildren<Animator>();
        a.SetTrigger("trigger");
        Consume(e);
    }
    public abstract void Consume(IoTEvent e);
    
}
