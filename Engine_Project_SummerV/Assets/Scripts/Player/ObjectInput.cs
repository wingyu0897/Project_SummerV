using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInput : MonoBehaviour
{
	[SerializeField] private AgentData playerData;
	Vector3 currentAngle = Vector3.zero;

    public UnityEvent<Vector2> OnMovementKeyPress;
	public UnityEvent<Vector2> OnPointerPositionChange;
	public UnityEvent<Vector3> OnPointerAngle;

	private void Update()
	{
		Movement();
		PointerPosition();
	}

	private void Movement()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		OnMovementKeyPress?.Invoke(new Vector2(x, y));
	}

	private void PointerPosition()
	{
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 0;
		Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
		OnPointerPositionChange?.Invoke(mouseWorldPos);

		Vector3 aimDirection = (Vector3)mouseWorldPos - transform.position;
		Vector3 desireAngle = new Vector3(0, 0, Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg);
		currentAngle = new Vector3(0, 0, Mathf.LerpAngle(currentAngle.z, desireAngle.z, playerData.turnSpeed));
		currentAngle.z = currentAngle.z >= 360 ? currentAngle.z - 360 : currentAngle.z <= 0 ? currentAngle.z + 360 : currentAngle.z;
		OnPointerAngle?.Invoke(currentAngle);
	}
}
