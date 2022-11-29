using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private LevelObjectSpawner[] levelObjectSpawner;
    [SerializeField] private int torchCount = 5;
    [SerializeField] private int obstacleCount = 5;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
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

    private void Start()
    {
        
    }

}
