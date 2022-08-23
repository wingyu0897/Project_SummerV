using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour, IInteractable
{
	private bool canActive = true;
	public bool CanActive => canActive;

	[SerializeField] private InteractionData interactionData;
	public InteractionData InteractionData => interactionData;

	[SerializeField] private Vector3 targetPos;

	[SerializeField] private Item IDCard;
	[SerializeField] private Item Crowbar;

	public void Init()
	{
	}

	private void Update()
	{
		if (GameManager.Instance.IsPowerOn == true)
		{
			interactionData.activeTime = 2f;
			interactionData.requireItem = IDCard;
		}
		else
		{
			interactionData.activeTime = 5f;
			interactionData.requireItem = Crowbar;
		}
	}

	public void OnInteraction()
	{
		if (GameManager.Instance.primaryItem?.name == interactionData.requireItem.name || GameManager.Instance.primaryItem?.name == Crowbar.name)
		{
			GameManager.Instance.player.transform.position = targetPos;
		}
		else
		{
			GameManager.Instance.InteractionText($"Need {interactionData.requireItem.name}");
		}
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		if (UnityEditor.Selection.activeObject == gameObject)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(targetPos, 0.5f);
			Gizmos.color = Color.white;
		}
	}
#endif
}
