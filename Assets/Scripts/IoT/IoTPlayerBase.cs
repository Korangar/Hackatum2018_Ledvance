using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Animations;

public abstract class IoTPlayerBase : SerializedMonoBehaviour
{
    private void OnEnable()
    {
        IoTManager.Add(this);
    }

    private void OnDisable()
    {
        IoTManager.Remove(this);
    }
    
    public void SetPhysicalBody(Transform t)
    {
        
        var constraint = gameObject.AddComponent<PositionConstraint>();
        var s = new ConstraintSource
        {
            sourceTransform = t,
            weight = 1
        };
        constraint.SetSource(0, s);
    }
}