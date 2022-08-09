using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementKeyPress;
	public UnityEvent<Vector2> OnPointerPositionChange;

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
	}
}
