using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Item, IInteractable
{
	private bool canActive = true;
	public bool CanActive => canActive;
	private bool isLight = true;

	[SerializeField] private GameObject lights;
	[SerializeField] private ToolData flashLightItemData;
	public override ToolData ItemData => flashLightItemData;

	[SerializeField] private InteractionData interactionData;
	public InteractionData InteractionData => interactionData;

	public override void Init()
	{
		lights.SetActive(false);
		GetComponent<SpriteRenderer>().sortingLayerName = "Item";
	}

	public override void UseItem()
	{
		isLight = isLight ? false : true;
		lights.SetActive(isLight);
	}

	public override void OnDrop()
	{
		canActive = true;
		lights.SetActive(false);
		transform.parent = null;
		transform.rotation = Quaternion.Euler(Vector3.zero);
		GetComponent<SpriteRenderer>().sortingLayerName = "Item";
	}

	public override void OnInteraction()
	{
		transform.localPosition = Vector3.zero;
		transform.localRotation = Quaternion.Euler(Vector3.zero);
		GetComponent<SpriteRenderer>().sortingLayerName = "PlayerFront";
		canActive = false;
	}
}
