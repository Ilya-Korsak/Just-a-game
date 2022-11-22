using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeshPlacer : MonoBehaviour
{
	private Coroutine movingCoroutine;
/*	private IEnumerator SmoothLerp(Vector2 direction)
	{
		Vector3 startingPos = transform.position;
		Vector3 finalPos = transform.position + (transform.forward * 5);
		float elapsedTime = 0;

		while (elapsedTime < time)
		{
			transform.position = Vector3.Slerp(startingPos, finalPos, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}*/
	public void OnMove(InputAction.CallbackContext context){
		Vector2 inputVector = context.ReadValue<Vector2>();
		Vector3 movementVectr = new Vector3(inputVector.x, 0, inputVector.y);
		Ray ray = new Ray(transform.TransformPoint
			(movementVectr), -transform.up);
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit))
		{
			transform.position = raycastHit.point;
			transform.rotation = Quaternion.FromToRotation(Vector3.up, raycastHit.normal);
		}
	}
}
