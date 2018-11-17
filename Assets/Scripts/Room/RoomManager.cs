using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RoomManager : SerializedMonoBehaviour
{
    public static List<Room> rooms = new List<Room>();
    public static List<RoomVisualization> visualizations = new List<RoomVisualization>();

    public RoomVisualization prefab;
    
    
    private static RoomManager Instance { get; set; }
    public static Transform Container => Instance?.transform;
    
    public static void Add(Room r)
    {
        rooms.Add(r);
        if (Instance) CreateVisuals(r);
    }

    public static void Remove(Room r)
    {
        rooms.Remove(r);
    }

    private static void CreateVisuals(Room r)
    {
        var i = Instantiate(Instance.prefab, r.transform.position, r.transform.rotation, Container);
        visualizations.Add(i);
        i.room = r;
    }
    
    private void Awake()
    {
        Instance = this;
        rooms.ForEach(CreateVisuals);
    }
}