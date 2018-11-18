using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.XR.Interaction;
using UnityEngine.SceneManagement;

public class FunctionKeyScenario : MonoBehaviour
{
    public KeyCode code;
    public int scenario;

    private bool loaded = false;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(code))
        {
            if (loaded)
            {
                SceneManager.UnloadSceneAsync(scenario);
            }
            else
            {
                SceneManager.LoadSceneAsync(scenario);
            }
        }    
    }
}
