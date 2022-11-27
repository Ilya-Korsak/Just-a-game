using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private AnimationController animationController;
    private Coroutine animationCoroutine = null;
    private SphereCharacterController sphereCharacterController;
    private void Awake()
    {
        sphereCharacterController = playerRigidBody.GetComponent<SphereCharacterController>();
    }
    IEnumerator AnimationCoroutine()
    {
        animationController.OnMove(MoovingType.JUMP);
        yield return new WaitForSeconds(0.3f);
        playerRigidBody.AddForce(playerRigidBody.transform.up * 5, ForceMode.Impulse);
        yield return new WaitForSeconds(0.8f);
        animationController.CancelJump();
        animationCoroutine = null;
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag== "Obstacle" && animationCoroutine==null)
        {
            Debug.Log(collider.gameObject.name);
            animationCoroutine = StartCoroutine(AnimationCoroutine());
        }
    }
}
