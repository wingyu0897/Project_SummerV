using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerInteraction : MonoBehaviour, IInteractable
{
	private bool canActive = true;
	public bool CanActive => canActive;

	[SerializeField] private InteractionData interactionData;
	public InteractionData InteractionData => interactionData;

	public void Init()
	{
		GameManager.Instance.IsPowerOn = false;
	}

	public void OnInteraction()
	{
		GameManager.Instance.IsPowerOn = GameManager.Instance.IsPowerOn ? false : true;
	}
}
