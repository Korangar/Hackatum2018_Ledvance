using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LookAtSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<LookAtConstraint>().AddSource(
            new ConstraintSource {
                sourceTransform = Camera.main.transform,
                weight = 1
            });
    }
}
