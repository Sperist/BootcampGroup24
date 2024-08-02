using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Syringe"))
        {
            SyringeManager.instance.TakeSyringe(other.gameObject);
        }

        if (other.CompareTag("MoleLevelEndCoroutine"))
        {
            if(SyringeManager.instance.syringeNumber == 3)
            {
                //level bitti yeni level
            }

            else
            {   
                //tüm þýrýngalarý topla komutu
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ClimbDetector"))
        {
            print("press F");  
            
            if(Input.GetKeyDown(KeyCode.F))
            {
                PlayerController.instance.isWalking = false;
                PlayerController.instance.isRunning = false;
                PlayerController.instance.isClimbing = true;

                //Press F yazýsý falan yazýlabilir
            }
        }
    }
}
