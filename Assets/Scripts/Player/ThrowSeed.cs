using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSeed : MonoBehaviour
{
    public static ThrowSeed instance;

    public bool canThrow;
    public bool wasThrowedSeed;

    [SerializeField] private GameObject childSeed;

    [SerializeField] private Rigidbody prefabSeedRigidbody;
    [SerializeField] private GameObject prefabSeed;

    [SerializeField] private Transform beehiveDoorTransform;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && canThrow)
        {
            StartCoroutine(ThrowingCoroutine());
        }
    }

    public void StartThrowCoroutine()
    {
        StartCoroutine (ThrowingCoroutine());
    }

    private IEnumerator ThrowingCoroutine()
    {
        PlayerController.instance.isThrowing = true;

        yield return new WaitForSeconds(0.3f);

        Destroy(childSeed);

        GameObject seed1 = Instantiate(prefabSeed, transform.position, transform.rotation);

        Rigidbody seed1Rigidbody = seed1.GetComponent<Rigidbody>();
        // seed1Rigidbody.AddForce(Vector3.forward * 40); // Bu kýsým þimdilik yorumlandý

        PlayerController.instance.isThrowing = false;

        float duration = 2.0f; // Hareket süresi
        float elapsedTime = 0.0f;

        Vector3 startingPos = seed1.transform.position;
        Vector3 targetPos = beehiveDoorTransform.position;

        while (elapsedTime < duration)
        {
            seed1.transform.position = Vector3.Lerp(startingPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        wasThrowedSeed = true;
        seed1.transform.position = targetPos; // Hedef pozisyona tam olarak ulaþmak için

    }
}
