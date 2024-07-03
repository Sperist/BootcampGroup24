using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody rb;
    public float dashDistance = 3f;
    public float dashCooldown = 1f;
    private bool canDash = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Dash();
        }
    }

    void Dash()
    {
        Vector3 dashDirection = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        Vector3 dashVector = dashDirection * dashDistance;
        rb.MovePosition(rb.position + dashVector);
        canDash = false;
        Invoke("ResetDash", dashCooldown);
    }

    void ResetDash()
    {
        canDash = true;
    }
}
