using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
public enum MoovingType
{
    IDLE,
    WALK,
    RUN,
    JUMP
}
public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnMove(MoovingType moovingType)
    {
        switch (moovingType)
        {
            case MoovingType.IDLE:
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isRuning", false);
                }
                break;
            case MoovingType.WALK:
                {
                    animator.SetBool("isRuning", false);
                    animator.SetBool("isWalking", true);
                }
                break;
            case MoovingType.RUN:
                {
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isRuning", true);
                }break;
            case MoovingType.JUMP:
                {
                    animator.SetLayerWeight(1, 0.8f);
                    animator.SetTrigger("doJump");
                }break;
        }
    }
    public void OnRotate(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            Vector3 pointToLook = new Vector3(
                (transform.localPosition.x+direction.x)*5,
                0,
                (transform.localPosition.z+direction.y)*5);
            transform.localRotation = Quaternion.LookRotation(pointToLook);
        }
    }

    internal void CancelJump()
    {
        animator.ResetTrigger("doJump");
        animator.SetLayerWeight(1, 0);
    }
}
