using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnStart : MonoBehaviour
{
    public int[] scenes;

    private void Awake()
    {
        foreach (var s in scenes) SceneManager.LoadSceneAsync(s, LoadSceneMode.Additive);
    }
}
