using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public void JumpToScene(string sceneName)
    {
        SceneController.Instance.LoadScene(sceneName);
    }
}
