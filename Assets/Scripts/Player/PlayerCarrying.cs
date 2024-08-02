using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarrying : MonoBehaviour
{
    [SerializeField] private List<GameObject> fixedPlanks = new List<GameObject>();
    [SerializeField] private List<GameObject> carryinPlanks = new List<GameObject>();

    public static PlayerCarrying instance;

    [SerializeField] private Transform carryingPointTransform;

    public bool isCarrying;
    private bool isCoroutineStarted;

    private int fixedPlankNumber;

    private GameObject planks;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isCarrying && other.gameObject.CompareTag("PlankBridge"))
        {

            if(Input.GetKey(KeyCode.F))
            {
                planks = other.gameObject;

                planks.transform.position = carryingPointTransform.position;
                planks.transform.rotation = carryingPointTransform.rotation ;
                planks.transform.SetParent(transform);

                isCarrying = true;

            }
        }

        if (!isCoroutineStarted && isCarrying && other.gameObject.CompareTag("BridgeFixer"))
        {

            if(Input.GetKey(KeyCode.F))
            {
                StartCoroutine(FixingBrdige());
            }
        }
    }

    private IEnumerator FixingBrdige()
    {
        isCoroutineStarted = true;

        foreach(Transform plank in planks.transform)
        {
            carryinPlanks.Add(plank.gameObject);
        }

        for (int i = 0; i < carryinPlanks.Count; i++)
        {
            Vector3 startingPos = carryinPlanks[i].transform.position;
            Vector3 targetPos = fixedPlanks[fixedPlankNumber].transform.position;

            float duration = 0.5f;
            float elapsedTime = 0.0f;


            while (elapsedTime < duration)
            {
                carryinPlanks[i].transform.position = Vector3.Lerp(startingPos, targetPos, elapsedTime / duration);
                elapsedTime += Time.deltaTime;

                carryinPlanks[i].transform.SetParent(null);

                yield return null;
            }

            fixedPlanks[fixedPlankNumber].gameObject.SetActive(true);
            carryinPlanks[i].transform.rotation = fixedPlanks[fixedPlankNumber].transform.rotation;

            fixedPlankNumber++;
        }

        planks.transform.SetParent(null);
        carryinPlanks.Clear();

        isCarrying = false;
        isCoroutineStarted=false;
    }
}
