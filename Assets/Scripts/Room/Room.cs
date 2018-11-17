using System.Collections;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

public class Room : MonoBehaviour
{   
    public float temperature;
    public float pressure;

    private void OnEnable()
    {
        RoomManager.Add(this);
    }

    private void OnDisable()
    {
        RoomManager.Remove(this);
    }
}
