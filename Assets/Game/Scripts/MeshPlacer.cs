using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeshPlacer : MonoBehaviour
{
    public InputAction moveAction;
    void Awake()
    {
        moveAction.performed += OnMove;
    }

    void OnEnable()
    {
        moveAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
    }
	void OnMove(CallbackContext context){

	}
	void Update () {
		Ray ray = new Ray (transform.position, Vector3.down);
		RaycastHit raycastHit;
		if (Physics.Raycast (ray, out raycastHit)) {
			transform.position = raycastHit.point;
			transform.rotation = Quaternion.FromToRotation (Vector3.up, raycastHit.normal);
		}
	}
}
