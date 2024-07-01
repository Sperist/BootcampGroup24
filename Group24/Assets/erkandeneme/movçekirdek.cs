using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movçekirdek : MonoBehaviour
{
    private float hiz = 10;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float yatayHareket = Input.GetAxis("Horizontal");
        float dikeyHareket = Input.GetAxis("Vertical");

        Vector3 hareket= new Vector3 (yatayHareket, 0.0f, dikeyHareket);

        rb.AddForce(hareket * hiz);

    }
}