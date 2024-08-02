using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public static SceneManagment instance;

    private void Awake()
    {
        instance = this;
    }

    public bool isSceneMapDesign()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Map Design")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
