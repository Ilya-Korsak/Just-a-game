using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchController : MonoBehaviour
{
    [SerializeField] private RectTransform joystick;
    private Vector2 inputVector = Vector2.zero;
    public void OnPoint(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        if (!joystick.gameObject.activeSelf)
        {
            joystick.position = inputVector;
        }
    }
    public void OnPress(InputAction.CallbackContext context)
    {
        bool isTouched = context.ReadValueAsButton();

            if (isTouched && !joystick.gameObject.activeSelf)
        {
            if (inputVector.y < Screen.resolutions[0].height-10)
            {
                joystick.gameObject.SetActive(true);
            }

            }
            else if (!isTouched && joystick.gameObject.activeSelf)
            {
                joystick.gameObject.SetActive(false);
            }
    }
}
