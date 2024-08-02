using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    void Start()
    {
        StartCoroutine(Cor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Cor()
    {
        yield return new WaitForSeconds(10);

        canvas.gameObject.SetActive(false);
    }
}
