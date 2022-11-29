using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchElement : MonoBehaviour
{
    public Action onTriggered;
    public bool isTriggered = false;
    public void OnTrigerred()
    {
        isTriggered = true;
        onTriggered?.Invoke();
    }
}
