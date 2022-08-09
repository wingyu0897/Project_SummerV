using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
	public UnityEvent<float> OnVelocityChange;

	[SerializeField] private float speed = 5f;
	[SerializeField] private float acceleration = 0.05f;
	[SerializeField] private float deAcceleration = 0.05f;
	
	private Rigidbody2D myRigid;

	private float currentVelocity = 0;
	private Vector2 moveDirection;

	private void Awake()
	{
		myRigid = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		OnVelocityChange?.Invoke(currentVelocity);
		myRigid.velocity = moveDirection * currentVelocity;
	}

	public void MovePlayer(Vector2 moveInput)
	{
		if (moveInput.sqrMagnitude > 0)
		{
			if (Vector2.Dot(moveInput, moveDirection) < 0)
			{
				currentVelocity = 0;
			}
			moveDirection = moveInput.normalized;
		}
		currentVelocity = Speed(moveInput);
	}

	private float Speed(Vector2 moveInput)
	{
		if (moveInput.sqrMagnitude > 0)
		{
			currentVelocity += acceleration * Time.deltaTime;
		}
		else
		{
			currentVelocity -= deAcceleration * Time.deltaTime;
		}

		return Mathf.Clamp(currentVelocity, 0, speed);
	}
}
