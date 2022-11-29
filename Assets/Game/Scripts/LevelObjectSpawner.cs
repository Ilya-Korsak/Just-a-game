using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject torchPrefab;
    [SerializeField] private GameObject[] obstaclePrefabs;

    private GameObject SpawnGameObject(GameObject prefab, float yOffset)
    {
        GameObject gameObject = Instantiate(prefab);
        gameObject.transform.SetParent(gameObject.transform, false);
        Vector3 newLocalPosition = Vector3.zero;
        newLocalPosition.y = yOffset;
        gameObject.transform.localPosition = newLocalPosition;
        return gameObject;
    }

    public GameObject SpawnTorch()
    {
        return SpawnGameObject(torchPrefab, 10);
    }
    public void SpawnObstacle()
    {
        SpawnGameObject(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], 1);
    }
}
