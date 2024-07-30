using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private CapsuleCollider capsuleCollider;

    private bool isGrounded = true;
    [SerializeField] private LayerMask groundMask;

    public bool isWalking;
    public bool isRunning;
    public bool isJumping;

    [SerializeField] private float walkingSpeed = 5f;
    [SerializeField] private float runningSpeed = 10f;
    [SerializeField] private float jumpHeight = -2f;

    private float moveSpeed;

    public float gravity = -9.81f;
    public Transform cameraTransform;
    public float rotationSpeed = 5.0f; // Rotasyon hýzýný ayarlamak için

    private CharacterController characterController;
    private Vector3 velocity;

    private void Awake()
    {
        instance = this;
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        moveSpeed = walkingSpeed;
    }

    private void Update()
    {
        Move();
        CheckGroundStatus();

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            StartCoroutine(JumpCoroutine());
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, vertical);
        move = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0) * move;
        move = move.normalized * moveSpeed;

        if (move != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = runningSpeed;

                isWalking = false;
                isRunning = true;
            }
            else
            {
                moveSpeed = walkingSpeed;

                isWalking = true;
                isRunning = false;
            }

            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        else
        {
            isRunning = false;
            isWalking = false;
        }

        if (isGrounded)
        {
            //isJumping = false;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move((move + velocity) * Time.deltaTime);
    }

    private IEnumerator JumpCoroutine()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.2f);
        characterController.height = 0.5f;
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        yield return new WaitForSeconds(0.6f);
        characterController.height = 2f;
        isJumping = false;
    }

    private void CheckGroundStatus()
    {
        Vector3 origin = transform.position + Vector3.down * (characterController.height / 2);
        isGrounded = Physics.Raycast(origin, Vector3.down, out RaycastHit hitInfo, (characterController.height) + 0.1f, groundMask);

        Debug.DrawRay(origin, Vector3.down * ((characterController.height)/2 + 0.1f), Color.red);
    }
}
