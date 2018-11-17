using System.Collections;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

public class Room : MonoBehaviour
{
    public static List<Room> rooms = new List<Room>();
    
    public float temperature;
    public float pressure;

    private void OnEnable()
    {
        rooms.Add(this);
    }

    private void OnDisable()
    {
        rooms.Remove(this);
    }
}
