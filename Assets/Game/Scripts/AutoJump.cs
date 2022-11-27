using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJump : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private AnimationController animationController;
    private Coroutine animationCoroutine = null;
    IEnumerator AnimationCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        playerRigidBody.AddForce(playerRigidBody.transform.up * 5, ForceMode.Impulse);
        yield return new WaitForSeconds(1);
        animationController.CancelJump();
        animationCoroutine = null;
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag== "Obstacle" && animationCoroutine==null)
        {
            Debug.Log(collider.gameObject.name);
            animationController.OnMove(MoovingType.JUMP);
            animationCoroutine = StartCoroutine(AnimationCoroutine());
        }
    }
   /* private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Obstacle" && animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            animationController.CancelJump();
            animationCoroutine =null;
            Debug.Log(collider.gameObject.name);
        }
    }*/
}
