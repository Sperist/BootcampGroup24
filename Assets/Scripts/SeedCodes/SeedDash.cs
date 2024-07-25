using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedDash : MonoBehaviour
{


    seedMovement moveScript;
    public float dashSpeed;
    public float dashTime;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<seedMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
