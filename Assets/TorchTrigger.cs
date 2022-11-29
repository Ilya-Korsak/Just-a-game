using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchTrigger : MonoBehaviour
{
    [SerializeField] private Transform objectToLookAt;
    [SerializeField] private Animator animator;
    [SerializeField] private TorchElement torchElement;
    private bool isOnFire = false;
    void OnTriggerEnter(Collider collider)
    {
        if (!isOnFire && collider.gameObject.tag == "Player")
        {
            PlayerActions playerActions = collider.gameObject.GetComponent<PlayerActions>();
            if (playerActions != null && playerActions.PerformAction(objectToLookAt))
            {
                animator.SetTrigger("isActivating");
                isOnFire = true;
                torchElement.OnTrigerred();
            }
        }
    }
}
