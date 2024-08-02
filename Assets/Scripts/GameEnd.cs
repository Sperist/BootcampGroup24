using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public static GameEnd instance;

    [SerializeField] private Canvas GameEndCanvas;

    public bool isLevelEnd;

    private void Awake()
    {
        instance = this;
    }

    public void StartGameEndCor()
    {
        StartCoroutine(GameEndCoroutine());
    }
    
    private IEnumerator GameEndCoroutine()
    {
        GameEndCanvas.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);

        Application.Quit();
    }
}
