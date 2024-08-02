using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private Canvas stopCanvas;

    private bool isStop;

    private void Update()
    {
        if(!isStop && Input.GetKey(KeyCode.Escape))
        {
            StopButton();
        }

        else if(isStop && Input.GetKey(KeyCode.Escape))
        {
            ContinueButton();
        }
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void StopButton()
    {
        Time.timeScale = 1.0f;
        stopCanvas.gameObject.SetActive(true);
    }

    public void ContinueButton()
    {
        stopCanvas.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
