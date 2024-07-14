using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    Camera cam;
    Vector2 firstpos;
    GameObject[] box_array;



    

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        firstpos = transform.position;
        
        box_array = GameObject.FindGameObjectsWithTag("box");
    }

    private void OnMouseDrag()
    {
        Vector3 puzzle_position = cam.ScreenToWorldPoint(Input.mousePosition);
        puzzle_position.z = 0;
        transform.position = puzzle_position;
        
    }

    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject box in box_array)
            {
                if (box.name == gameObject.name)
                {
                    float box_distance = Vector3.Distance(box.transform.position, transform.position);

                    if(box_distance <= 1)
                    {
                        transform.position = box.transform.position;
                    }
                    else
                    {
                        transform.position = firstpos;
                    }
                }
            }
        }
    }
}
