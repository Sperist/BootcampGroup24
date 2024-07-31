using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotus : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("plads");

            rb.velocity = Vector3.down * 1;
        }
    }
}