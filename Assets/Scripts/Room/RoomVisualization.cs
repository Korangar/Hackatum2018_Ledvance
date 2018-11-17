using Sirenix.OdinInspector;
using UnityEngine;

public class RoomVisualization : SerializedMonoBehaviour
{
    public Room room;
    public ParticleSystem particles;
    
    
    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
        transform.localScale = room.transform.lossyScale;
    }
}
