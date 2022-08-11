using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
	public UnityEvent<Vector2> OnVelocityChange;

	[SerializeField] private AgentData playerData;
	public AgentData PlayerData { get => playerData; }
	
	private Rigidbody2D myRigid;

	private float currentVelocity = 0;
	private Vector2 moveDirection;

	private void Awake()
	{
		myRigid = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		OnVelocityChange?.Invoke(myRigid.velocity);
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
			currentVelocity += playerData.acceleration * Time.deltaTime;
		}
		else
		{
			currentVelocity -= playerData.deAcceleration * Time.deltaTime;
		}

		return Mathf.Clamp(currentVelocity, 0, playerData.speed);
	}
}
