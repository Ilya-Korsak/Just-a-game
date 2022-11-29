using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject torchPrefab;
    [SerializeField] private GameObject[] obstaclePrefabs;

    private GameObject SpawnGameObject(GameObject prefab, float yOffset)
    {
        GameObject newObject = Instantiate(prefab);
        newObject.transform.SetParent(gameObject.transform);
        Vector3 newLocalPosition = Vector3.zero;
        newLocalPosition.y = yOffset;
        newObject.transform.localPosition = newLocalPosition;
        newObject.transform.localRotation = Quaternion.identity;
        return newObject;
    }

    public GameObject SpawnTorch()
    {
        return SpawnGameObject(torchPrefab, -0.2f);
    }
    public void SpawnObstacle()
    {
        SpawnGameObject(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], 0.1f);
    }
}
