using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Item, IInteractable
{
	private bool canActive = true;
	public bool CanActive => canActive;

	private bool isActive = true;

	[SerializeField] private ToolData flashLightData;
	public ToolData FlashLightData
	{
		get => flashLightData;
		set => flashLightData = value;
	}
	[SerializeField] private GameObject lights;
	

	[SerializeField] private InteractionData interactionData;
	public InteractionData InteractionData => interactionData;

	public override void Init()
	{
		lights.SetActive(false);
		GetComponent<SpriteRenderer>().sortingLayerName = "Item";
	}

	public override void UseItem()
	{
		isActive = isActive ? false : true;
		lights.SetActive(isActive);
	}

	public override ToolData ReturnData()
	{
		return flashLightData;
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
