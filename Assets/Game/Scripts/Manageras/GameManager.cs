using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private LevelObjectSpawner[] levelObjectSpawner;
    [SerializeField] private int torchCount = 5;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private List<TorchElement> spawnedTorches;
    [SerializeField] private int activatedTorchCount = 0;
    [SerializeField] private RectTransform playerControlsUI;
    [SerializeField] private RectTransform finishWindow;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void TorchActivated()
    {
        Debug.Log("Activated");
        activatedTorchCount++;
        scoreText.text = activatedTorchCount + "/" + torchCount;
        if(torchCount == activatedTorchCount)
        {
            playerControlsUI.gameObject.SetActive(false);
            finishWindow.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        if (torchCount > levelObjectSpawner.Length)
        {
            Debug.LogError("Spawners count should be more than TorchCount");
            throw new Exception();
        }
        List<int> usedSpawnersList = new List<int>();
        int nextIndex = RandomRangeExcept(0, levelObjectSpawner.Length, usedSpawnersList);
        while (nextIndex != -1)
        {
            usedSpawnersList.Add(nextIndex);
            if (spawnedTorches.Count < torchCount)
            {
                torchCount++;
                TorchElement newTorchElement = levelObjectSpawner[nextIndex].SpawnTorch().GetComponent<TorchElement>();
                newTorchElement.onTriggered += TorchActivated;
                spawnedTorches.Add(newTorchElement);
            }
            else
            {
                levelObjectSpawner[nextIndex].SpawnObstacle();
            }
        }
    }

    public static int RandomRangeExcept(int minVal, int maxVal, List<int> except = null)
    {
        IEnumerable<int> allowedRandomNumbers = Enumerable.Range(minVal, maxVal - minVal);
        if (except != null)
        {
            allowedRandomNumbers = allowedRandomNumbers.Except(except);
        }
        if (allowedRandomNumbers.Count() == 0)
        {
            return -1;//When we out of random
        }
        int randomIndex = UnityEngine.Random.Range(0, allowedRandomNumbers.Count());
        return allowedRandomNumbers.ElementAt(randomIndex);
    }

}
