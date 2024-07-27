using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeFalling : MonoBehaviour
{
    [System.Serializable]
    public class TransformData
    {
        public Transform transform;
        public bool isInstantiated = false;
    }

    [SerializeField] private List<TransformData> transformDataList = new List<TransformData>();

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject conePrefab;
    [SerializeField] private GameObject warningPrefab;

    [SerializeField] private float distance;
    [SerializeField] private float fallingHigh;

    [SerializeField] private float maxZ;
    [SerializeField] private float minZ;

    void Update()
    {
        for (int i = 0; i < transformDataList.Count; i++)
        {
            TransformData transformData = transformDataList[i];
            if (Vector3.Distance(transformData.transform.position, player.transform.position) < distance && !transformData.isInstantiated)
            {
                float randomZ = Random.Range(minZ, maxZ);
                Vector3 insPos = new Vector3(transformData.transform.position.x, fallingHigh, randomZ);
                Vector3 insWarningPos = new Vector3(transformData.transform.position.x, 0, randomZ);
                Instantiate(warningPrefab, insWarningPos, Quaternion.identity);
                Instantiate(conePrefab, insPos, Quaternion.identity);
                transformData.isInstantiated = true;
            }
        }
    }
}
