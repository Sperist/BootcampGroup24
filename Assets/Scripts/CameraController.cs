using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float distance = 5.0f;
    private float firstDistance;

    public Vector2 sensitivity = new Vector2(100, 100);
    public Vector2 pitchLimits = new Vector2(-40, 85);

    private Vector2 rotation;

    [SerializeField] private LayerMask wallMask;

    private bool isWall;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        firstDistance = distance;
    }

    private void Update()
    {
        //ChangeDistance();
        Debug.DrawRay(target.position, -transform.forward * distance, Color.red);
    }

    private void LateUpdate()
    {
        WallControl();
        FollowTarget();
    }

    private void FollowTarget()
    {if (!isWall)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            rotation.x += mouseX * sensitivity.x * Time.deltaTime;
            rotation.y -= mouseY * sensitivity.y * Time.deltaTime;
            rotation.y = Mathf.Clamp(rotation.y, pitchLimits.x, pitchLimits.y);

            Quaternion targetRotation = Quaternion.Euler(rotation.y, rotation.x, 0);
            Vector3 desiredPosition = target.position - targetRotation * Vector3.forward * distance;

            transform.position = desiredPosition;
            transform.LookAt(target);
        }

        else
        {
            float mouseX = -Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            rotation.x += mouseX * sensitivity.x * Time.deltaTime;
            rotation.y -= mouseY * sensitivity.y * Time.deltaTime;
            rotation.y = Mathf.Clamp(rotation.y, pitchLimits.x, pitchLimits.y);

            Quaternion targetRotation = Quaternion.Euler(rotation.y, rotation.x, 0);
            Vector3 desiredPosition = target.position - targetRotation * Vector3.forward * distance;

            transform.position = desiredPosition;
            transform.LookAt(target);
        }
        }

    private void WallControl()
    {
        RaycastHit hitInfo;
        Vector3 desiredCameraPos = target.position - transform.rotation * Vector3.forward * firstDistance;

        if (Physics.Raycast(target.position, -transform.forward, out hitInfo, firstDistance, wallMask))
        {
            isWall = true;
        }
        else if(!Physics.Raycast(target.position, -transform.forward, out hitInfo, firstDistance, wallMask))
        {
            isWall= false;
        }
    }
}