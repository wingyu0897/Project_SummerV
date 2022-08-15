using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
	public UnityEvent<Item> onInteraction;

    [SerializeField] private Image interactionIcon;
	[SerializeField] private KeyCode interactionKeyCode;

	private List<IInteractable> interactables = new List<IInteractable>();
	private IInteractable primaryInteraction = null;
	private float interactionTime = 0;

	private void Update()
	{
		PrimaryInteractionSelector();
		SetInteractionIcon();
		OnInteraction();
	}

	private void PrimaryInteractionSelector()
	{
		if (interactables.Count <= 0)
		{
			primaryInteraction = null;
		}
		else if (interactables.Count == 1)
		{
			primaryInteraction = interactables[0];
		}
		else
		{
			if (primaryInteraction.CanActive == false)
			{
				interactables.Remove(primaryInteraction);
			}
			foreach (IInteractable f in interactables)
			{
				if (Vector3.Distance(transform.position, f.gameObject.transform.position) <
						Vector3.Distance(transform.position, primaryInteraction.gameObject.transform.position))
				{
					primaryInteraction = f;
				}
			}
		}
	}

	private void SetInteractionIcon()
	{
		if (primaryInteraction != null && primaryInteraction.CanActive == true)
		{
			interactionIcon.gameObject.SetActive(true);
			interactionIcon.fillAmount = interactionTime / primaryInteraction.InteractionData.interactionTime;
			interactionIcon.transform.position = Camera.main.WorldToScreenPoint(primaryInteraction.gameObject.transform.position);
		}
		else
		{
			interactionIcon.gameObject.SetActive(false);
		}
	}

	private void OnInteraction()
	{
		if (Input.GetKey(interactionKeyCode))
		{
			if (primaryInteraction != null)
			{
				interactionTime += Time.deltaTime;
				if (interactionTime >= primaryInteraction.InteractionData.interactionTime)
				{
					switch (primaryInteraction.InteractionData.interactionType)
					{
						case InteractionType.Item :
							onInteraction?.Invoke(primaryInteraction.gameObject.GetComponent<Item>());
							break;
					}
				}
			}
			else
			{
				interactionTime = 0;
			}
		}
		else
		{
			interactionTime = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<IInteractable>() != null && 
			collision.gameObject.GetComponent<IInteractable>().CanActive == true)
		{
			interactables.Add(collision.GetComponent<IInteractable>());
			if (primaryInteraction == null)
			{
				primaryInteraction = interactables[0];
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<IInteractable>() != null &&
			collision.gameObject.GetComponent<IInteractable>().CanActive == true)
		{
			interactables.Remove(collision.GetComponent<IInteractable>());
		}
	}
}
