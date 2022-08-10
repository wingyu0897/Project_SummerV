using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
	[SerializeField] private string backwardSortingLayer;
	[SerializeField] private string forwardSortingLayer;

	private AgentData playerData;
	private SpriteRenderer myRenderer;
	private Animator myAnimator;

	private readonly int faceDirectionHash = Animator.StringToHash("Front");
	private readonly int walkHash = Animator.StringToHash("Walk");

	private bool isWalking = false;
	private bool faceBack = false;

	private void Awake()
	{
		playerData = transform.parent.gameObject.GetComponent<PlayerMovement>().PlayerData;
		myRenderer = GetComponent<SpriteRenderer>();
		myAnimator = GetComponent<Animator>();
	}

	public void FaceDirection(Vector3 pointerInput)
	{
		faceBack = pointerInput.z < playerData.turnBackwardMinDeg || pointerInput.z > playerData.turnBackwardMaxDeg;
		myRenderer.sortingLayerName = faceBack ? forwardSortingLayer : backwardSortingLayer;
		myAnimator.SetBool(faceDirectionHash, faceBack ? true : false);
	}

	public void FlipX(Vector2 pointerInput)
	{
		Vector3 direction = (Vector3)pointerInput - transform.position;
		Vector3 result = Vector3.Cross(Vector2.up, direction);

		myRenderer.flipX = result.z > 0;
	}

	public void AnimatePlayer(float velocity)
	{
		isWalking = velocity > 0;
		SetWalkAnimation(isWalking);
	}

	public void SetWalkAnimation(bool value)
	{
		myAnimator.SetBool(walkHash, value);
	}
}
