using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereCharacterController : MonoBehaviour
{
    private Vector3 movingVector = Vector3.zero;
    [SerializeField] private AnimationController animationController;
    [SerializeField] private float characterOverallSpeed = 1.0f;
    [SerializeField] private float inputSpeedMultipler = 0.0f;
    private Rigidbody rigidBody;
    Vector2 inputVector = Vector2.zero;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (movingVector != Vector3.zero)
        {
            rigidBody.MovePosition(rigidBody.position + transform.TransformDirection((movingVector / 20) * inputSpeedMultipler * characterOverallSpeed));
            animationController.OnRotate(inputVector);
        }
    }
    private float GetSpeedMultipler()//make two speed walk (like gearbox with 2 gears)
    {
        float srcFloat = Mathf.Abs(inputVector.y) + Mathf.Abs(inputVector.x);
        float resultFloat = Mathf.RoundToInt(srcFloat);
        return resultFloat > 2 ? 2 : resultFloat;//returns 0.0f or 1f or 2.0f
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
