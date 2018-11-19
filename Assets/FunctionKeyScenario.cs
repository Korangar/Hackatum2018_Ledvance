using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionKeyScenario : MonoBehaviour
{
    public KeyCode code;
    public int scenario;

    private bool loaded;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(code))
        {
            if (loaded)
            {
                SceneManager.UnloadSceneAsync(scenario);
                loaded = false;
            }
            else
            {
                SceneManager.LoadSceneAsync(scenario, LoadSceneMode.Additive);
                loaded = true;
            }
        }    
    }
}
