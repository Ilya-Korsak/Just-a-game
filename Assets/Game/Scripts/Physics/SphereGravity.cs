using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SphereGravity : MonoBehaviour
{
    public static SphereGravity Instance { get; private set; }
    [SerializeField] private float sphereGravity = -10;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("This singleton already exists");
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void Pull(Transform targetTransform)
    {
        Vector3 targetVector = (targetTransform.position - transform.position).normalized;
        Vector3 targetUp = targetTransform.up;

        targetTransform.rotation = Quaternion.FromToRotation(targetUp, targetVector) * targetTransform.rotation;
        targetTransform.GetComponent<Rigidbody>().AddForce(targetVector*sphereGravity);
    }
}
