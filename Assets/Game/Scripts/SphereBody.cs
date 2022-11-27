using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class SphereBody : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movingVector = Vector3.zero;    
    [SerializeField] private AnimationController animationController;
    [SerializeField] private float characterOverallSpeed = 1.0f;
    [SerializeField] private float inputSpeedMultipler = 0.0f;
    Vector2 inputVector=Vector2.zero;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void FixedUpdate()
    {
        SphereGravity.Instance.Pull(transform);
        if (movingVector != Vector3.zero)
        {
            //XD Debug.Log(movingVector / 0);
            rb.MovePosition(rb.position + transform.TransformDirection((movingVector/20)* inputSpeedMultipler * characterOverallSpeed));

            animationController.OnRotate(inputVector);
        }
    }
    private float GetSpeedMultipler()//make two speed walk (like gearbox with 2 gears)
    {
        float srcFloat = Mathf.Abs(inputVector.y) + Mathf.Abs(inputVector.x);
        float resultFloat = Mathf.RoundToInt(srcFloat);
        return resultFloat>2?2:resultFloat;//returns 0.0f or 1f or 2.0f
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        inputSpeedMultipler = GetSpeedMultipler();
        //ADD FORCE WAS SOO FUN :C rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y)*5, ForceMode.Acceleration);
        movingVector = new Vector3(inputVector.x, 0, inputVector.y).normalized;
        MoovingType moovingType = MoovingType.IDLE;
        switch (inputSpeedMultipler)
        {
            case 1.0f:
                {
                    moovingType = MoovingType.WALK;
                }
                break;
            case 2.0f:
                {
                    moovingType = MoovingType.RUN;
                }
                break;
        }
        animationController.OnMove(moovingType);
    }
}
