using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoTInitializer : MonoBehaviour
{
    public IoTPlayerBase[] objects;

    private void Awake()
    {
        foreach (var o in objects)
        {
            var i = Instantiate(o, transform.position, transform.rotation);
            i.SetPhysicalBody(transform);
        }
    }
}
