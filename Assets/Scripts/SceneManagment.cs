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

    private void Start()
    {
    }
    public bool isSceneMapDesign()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MainScene")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isSceneMapDesign1()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MainScene 1")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void LoadMoleScene()
    {
        SceneManager.LoadScene("MoleHole");
    }

    public void LoadBeehiveScene()
    {
        SceneManager.LoadScene("Beehive");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMainScene1()
    {
        SceneManager.LoadScene("MainScene 1");
    }
}
