using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanNavigationTargetHelper : MonoBehaviour
{
    public void SetTarget(Transform t)
    {
        GetComponent<NavMeshAgent>().SetDestination(t.position);
    }
}
