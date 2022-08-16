using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
	private bool canActive = true;
	public bool CanActive => canActive;

	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Collider2D doorCollider;
	[SerializeField] private InteractionData interactionData;
	public InteractionData InteractionData => interactionData;

	public void Init()
	{
		StopAllCoroutines();
		spriteRenderer.sprite = interactionData.idleSprite;
		doorCollider.enabled = true;
		canActive = true;
	}

	public void OnInteraction()
	{
		if (GameManager.Instance.IsPowerOn == true)
		{
			StartCoroutine(CoOpenDoor());
		}
		else
		{
			GameManager.Instance.PopText("There is no power");
		}
	}

	IEnumerator CoOpenDoor()
	{
		canActive = false;
		Debug.Log(canActive);
		spriteRenderer.sprite = interactionData.interactionSprite;
		doorCollider.enabled = false;

		yield return new WaitForSeconds(interactionData.activeTime);

		canActive = true;
		spriteRenderer.sprite = interactionData.idleSprite;
		doorCollider.enabled = true;
	}
}
