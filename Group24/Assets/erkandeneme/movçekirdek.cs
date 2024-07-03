using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movçekirdek : MonoBehaviour
{
    public float hiz = 5f;
    private Rigidbody rb;
    private float slowedSpeed;
    private bool isOnHoney = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        slowedSpeed = hiz - 3f;
    }

    
    void Update()
    {
        float yatayHareket = Input.GetAxis("Horizontal");
        float dikeyHareket = Input.GetAxis("Vertical");

        Vector3 hareket= new Vector3 (yatayHareket, 0.0f, dikeyHareket);

        rb.AddForce(hareket * hiz);

        if (isOnHoney)
        {
            rb.velocity = hareket * slowedSpeed;
        }
        else
        {
            rb.velocity = hareket * hiz;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Honey"))
        {
            isOnHoney = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Honey"))
        {
            isOnHoney = false;
        }
    }
}