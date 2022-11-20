using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeshPlacer : MonoBehaviour
{
	public void OnMove(InputAction.CallbackContext context){
		Vector2 inputVector = context.ReadValue<Vector2>();
		Vector3 movementVectr = new Vector3(inputVector.x, 0, inputVector.y);
		Ray ray = new Ray(transform.TransformPoint(movementVectr), -transform.up);
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit))
		{
			transform.position = raycastHit.point;
			transform.rotation = Quaternion.FromToRotation(Vector3.up, raycastHit.normal);
		}
	}
}
