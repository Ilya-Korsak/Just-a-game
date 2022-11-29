using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] ParticleSystem actionParticleSystem;
    [SerializeField] float actionDuration = 1.0f;
    private Coroutine delayCoroutine = null;

    IEnumerator ActionDelayCoroutine(Transform lookTo)
    {
        actionParticleSystem.Play();
        float delayTeime = 0;
        while (delayTeime < actionDuration)
        {
            delayTeime += Time.deltaTime;
            actionParticleSystem.transform.LookAt(lookTo.position);
            yield return new WaitForEndOfFrame();
        }
        actionParticleSystem.Stop();
        delayCoroutine = null;
    }

    public bool PerformAction(Transform lookTo)
    {
        if (delayCoroutine == null)
        {
            delayCoroutine = StartCoroutine(ActionDelayCoroutine(lookTo));
            return true;
        }
        else
        {
            return false;
        }
    }

}
