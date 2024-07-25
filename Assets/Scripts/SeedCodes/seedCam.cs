using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seedCam : MonoBehaviour
{
    public Transform target;
    public Vector2 sensitivity = new Vector2(100, 100);
    public float distance = 5.0f;
    public Vector2 pitchLimits = new Vector2(-40, 85);

    private Vector2 rotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotation.x += mouseX * sensitivity.x * Time.deltaTime;
        rotation.y -= mouseY * sensitivity.y * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, pitchLimits.x, pitchLimits.y);

        Quaternion targetRotation = Quaternion.Euler(rotation.y, rotation.x, 0);
        Vector3 targetPosition = target.position - targetRotation * Vector3.forward * distance;

        transform.position = targetPosition;
        transform.LookAt(target);
    }
}
