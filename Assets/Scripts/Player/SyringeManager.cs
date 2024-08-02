using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeManager : MonoBehaviour
{
    public static SyringeManager instance;

    public int syringeNumber;

    private void Awake()
    {
        instance = this;
    }
    
    public void TakeSyringe(GameObject other)
    {
        other.gameObject.SetActive(false);
        syringeNumber++;
    }
}
