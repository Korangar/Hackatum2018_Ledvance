using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class IoTEventVisualizer : SerializedMonoBehaviour
{
    private const float speed = 1/1.5f;
    
    public IoTEvent e;
    public IoTConsumer consumer;

    private void Update()
    {
        var travel = Vector3.Distance(e.from.transform.position, transform.position);
        var distance = Vector3.Distance(e.from.transform.position, consumer.transform.position);
        
        transform.position = Vector3.Lerp(e.from.transform.position, consumer.transform.position, travel/distance + speed * Time.deltaTime);
        if (distance - travel < .5f)
        {
            Resolve();
        }
    }
    
    public void Resolve() 
    {
        enabled = false;
        consumer.DoConsume(e);
        var time = GetComponent<TrailRenderer>().time;
        Destroy(gameObject, time);
    } 
}
