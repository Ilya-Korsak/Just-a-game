using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Material material;
    //public BallSpawner spawner;
    const float offset = 0.05f;
    IEnumerator ColorChangerCoroutine()
    {
        var delay = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return delay;

            material.color = new Color(
                (Mathf.Sin(Time.realtimeSinceStartup + (offset * transform.localPosition.x)) + 1) / 2,
                0.3f, 0.5f);
        }
    }
    private void Start()
    {
        material = GetComponent<Renderer>().material;
        StartCoroutine(ColorChangerCoroutine());
    }
}
