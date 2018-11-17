using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    public GameObject[] objects;

    private void Awake()
    {
        foreach (var o in objects) Instantiate(o, transform.position, transform.rotation);
    }
}
