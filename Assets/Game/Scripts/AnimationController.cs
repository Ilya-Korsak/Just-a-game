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
                }
                break;
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
            /* Vector3 stickInput3 = new Vector3(direction.x, 0f, direction.y);
             Vector3 axisOfRotation = Vector3.Cross(Vector3.up, stickInput3);
             float angleOfRotation = 180f * Mathf.Min(1f, direction.magnitude);
             transform.localRotation = Quaternion.AngleAxis(angleOfRotation, axisOfRotation);*/
        }
    }
}
