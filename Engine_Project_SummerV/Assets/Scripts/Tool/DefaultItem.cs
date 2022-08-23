using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultItem : Item, IInteractable
{
	private bool canActive = true;
	public bool CanActive => canActive;

	[SerializeField] private ToolData cardItemData;
	public override ToolData ItemData => cardItemData;

	[SerializeField] private InteractionData interactionData;
	public InteractionData InteractionData => interactionData;


	public override void Init()
	{
		GetComponent<SpriteRenderer>().sortingLayerName = "Item";
	}

	public override void OnDrop()
	{
		transform.parent = null;
		transform.rotation = Quaternion.Euler(Vector3.zero);
		GetComponent<SpriteRenderer>().sortingLayerName = "Item";
	}

	public override void OnInteraction()
	{
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.Euler(Vector3.zero);
		GetComponent<SpriteRenderer>().sortingLayerName = "PlayerFront";
	}

	public override void UseItem()
	{
		
	}
}
