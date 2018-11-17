using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

public class IoTManager : SerializedMonoBehaviour
{
    public static List<IoTSensor> sensors = new List<IoTSensor>();
    public static List<IoTConsumer> consumers = new List<IoTConsumer>();
    public static List<IoTEvent> eventHistory = new List<IoTEvent>();
    
    public IoTEventVisualizer visualizerPrefab;
    

    private static IoTManager Instance { get; set; }
    public static Transform Container => Instance?.transform;
    
    
    public static void Add(IoTSensor sensor)
    {
        if(Container)sensor.transform.SetParent(Container);
        sensors.Add(sensor);
    }

    public static void Add(IoTConsumer consumer)
    {
        if(Container)consumer.transform.SetParent(Container);
        consumers.Add(consumer);
    }

    public static void Remove(IoTSensor sensor)
    {
        sensors.Remove(sensor);
    }

    public static void Remove(IoTConsumer consumer)
    {
        consumers.Remove(consumer);
    }

    public static void Broadcast(IoTEvent e)
    {
        eventHistory.Add(e);
        if (eventHistory.Count > 1000)
        {
            eventHistory.RemoveAt(0);
        }
        
        var targets =
            from target in consumers 
            where target.IsEventMatch(e) 
            select target;

        foreach (var t in targets)
        {
            var i = Instantiate(Instance.visualizerPrefab, e.from.transform.position, Quaternion.identity, Container);
            i.consumer = t;
            i.e = e;
        }
    }

    private void Awake()
    {
        Instance = this;

        var transforms = Enumerable.Concat(
            sensors.ConvertAll(s => s.transform), 
            consumers.ConvertAll(c=>c.transform));

        transforms.ForEach(t => t.SetParent(transform));
    }
}