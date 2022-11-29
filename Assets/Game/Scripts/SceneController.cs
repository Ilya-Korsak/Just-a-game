using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    [SerializeField] private RectTransform loaderCanvas;
    [SerializeField] private Image progressBar;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);  
        }
    }

    public async void LoadScene(string sceneName) { 
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;
        loaderCanvas.gameObject.SetActive(true);
        
        while (scene.progress < 0.9f){
            await Task.Delay(100);
            progressBar.fillAmount = scene.progress;
        }

        loaderCanvas.gameObject.SetActive(false);
        scene.allowSceneActivation = true;
    }
}
