using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.SceneManagement;

public class FunctionKeyToggle : MonoBehaviour
{
    public KeyCode code;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(code))
        {            
            cam.enabled = !cam.enabled;
        }    
    }
}
