using Sirenix.OdinInspector;
using UnityEngine;

public class RoomVisualization : SerializedMonoBehaviour
{
    public Room room;
    public ParticleSystem particles;

    public float Area => room.transform.lossyScale.x *
                         room.transform.lossyScale.y *
                         room.transform.lossyScale.z;
                         
    
    public void Initialize(Room r)
    {
        room = r;
        particles = GetComponent<ParticleSystem>();
        
        var shape = particles.shape;
        shape.shapeType = ParticleSystemShapeType.Box;
        shape.scale = r.transform.lossyScale;
        
        var emission = particles.emission;
        emission.rateOverTime = 2.5f * Area;
    }
}
