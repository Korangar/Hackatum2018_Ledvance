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

        SetTemperature();
    }

    private void SetTemperature()
    {
        var main = particles.main;
        float normedTemp = 1.0f * room.temperature / 30f;
        if (normedTemp < 0.5)
            main.startColor = new Color(normedTemp * 2, normedTemp * 2, 1 - normedTemp * 2);
        else
        {
            main.startColor = new Color(1, 1 - (normedTemp - 0.5f) * 2, 0);
        }
    }

    private void Update()
    {
        SetTemperature();
    }
}
