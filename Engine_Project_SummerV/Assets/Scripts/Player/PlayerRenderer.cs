using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
	[SerializeField] private string backwardSortingLayer;
	[SerializeField] private string forwardSortingLayer;

	private SpriteRenderer myRenderer;
	private Animator myAnimator;

	private readonly int faceDirectionHash = Animator.StringToHash("Front");
	private readonly int walkHash = Animator.StringToHash("Walk");

	private bool isWalking = false;

	private void Awake()
	{
		myRenderer = GetComponent<SpriteRenderer>();
		myAnimator = GetComponent<Animator>();
	}

	public void FaceDirection(Vector2 pointerInput)
	{
		Vector3 direction = (Vector3)pointerInput - transform.position;
		Vector3 result = Vector3.Cross(Vector2.up, direction);
		Vector3 face = Vector3.Cross(Vector2.right, direction);


		myRenderer.sortingLayerName = face.z > 0 ? backwardSortingLayer : forwardSortingLayer;
		myAnimator.SetBool(faceDirectionHash, face.z < 0 ? true : false);
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
