using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int cubeSize=15;
    [SerializeField] Material[] materials;
    //[SerializeField] TMP_Text fpsText;
    public float offset = 0.1f;
    IEnumerator ColorChangerCoroutine()
    {
        var delay = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return delay;
            for (int i=0; i<cubeSize; i++)
            {
                materials[i].color = new Color(
                    (Mathf.Sin(Time.realtimeSinceStartup + (offset * i)) + 1) / 2,
                    0.3f, 0.5f);
            }
        }
    }
    private void Start()
    {
        Application.targetFrameRate = Screen.resolutions[0].refreshRate;
        materials = new Material[cubeSize];
        //offset = 0.1f;//360/count;
        for(int x=0; x< cubeSize; x++)  
        {
           for(int y=0; y< cubeSize; y++)
           {
                for (int z = 0; z < cubeSize; z++)
                {
                    GameObject newObject = Instantiate(prefab);
                    newObject.transform.SetParent(transform, false);
                    // newObject.GetComponent<ColorChanger>().spawner = this;
                    newObject.transform.localPosition = new Vector3(x, y, z);
                    if (y == 0&& z==0)
                    {
                        materials[x] = newObject.GetComponent<Renderer>().material;
                    }
                    else
                    {
                        newObject.GetComponent<Renderer>().material = materials[x];
                    }
                }
            }
        }
       StartCoroutine(ColorChangerCoroutine());
    }
}
