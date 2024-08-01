using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFalling : MonoBehaviour
{
    public static PlayerFalling instance;

    [SerializeField] private Transform secondPoint;
    [SerializeField] private Transform thirdPoint;
    [SerializeField] private Transform fourthPoint;

    Quaternion rot;

    public bool isHanging;
    public bool isFalling;

    public bool isGettingUP;

    [SerializeField] private float firstGravity;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        firstGravity = PlayerController.instance.gravity;
        PlayerController.instance.gravity = 0;
        isHanging = true;

        StartCoroutine(FirstFallingCoroutine());
    }

    private void Update()
    {
        if (isFalling)
        {
            rot = Quaternion.Euler(2, 2,1);
            transform.Rotate(rot.eulerAngles);
        }
    }

    private IEnumerator FirstFallingCoroutine()
    {
        yield return new WaitForSeconds(5);

        PlayerController.instance.gravity = firstGravity;

        isFalling = true;

        float duration = 3.0f;
        float elapsedTime = 0.0f;

        Vector3 startingPos = transform.position;
        Vector3 targetPos = fourthPoint.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isHanging = false;
        isFalling = false;

        transform.rotation= Quaternion.identity;

        isGettingUP = true;

        PlayerController.instance.canMove = false;
        yield return new WaitForSeconds(7.5f);

        isGettingUP = false;
        PlayerController.instance.canMove = true;
    }
}
