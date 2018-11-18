using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.Physics;
using Object = System.Object;

public abstract class IoTPlayerBase : SerializedMonoBehaviour
{
    public string location;
    
    private void OnEnable()
    {
        IoTManager.Add(this);
        RaycastHit hitInfo;
        Collider[] cols;
        cols = OverlapSphere(transform.position, 0.1f, LayerMask.GetMask("Room"));
        if (cols.Length > 0)
        {
            location = cols[0].transform.name;
        }
        else
        {
            location = "Outside";
        }
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
        constraint.AddSource(s);
        constraint.constraintActive = true;
    }
}