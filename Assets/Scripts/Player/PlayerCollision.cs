using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
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
