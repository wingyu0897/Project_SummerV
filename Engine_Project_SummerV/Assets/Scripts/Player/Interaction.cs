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
		if (primaryInteraction?.CanActive == false)
		{
			interactables.Remove(primaryInteraction);
		}
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
			foreach (IInteractable f in interactables) //가장 가까운 오브젝트로 결정
			{
				if (Vector3.Distance(transform.position, f.gameObject.transform.position) <
						Vector3.Distance(transform.position, primaryInteraction.gameObject.transform.position))
				{
					interactionTime = 0;
					primaryInteraction = f;
				}
			}
		}
	}

	private void SetInteractionIcon()
	{
		if (primaryInteraction?.CanActive == true)
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
					interactionTime = 0;
					GameManager.Instance.InteractionText(primaryInteraction.InteractionData.interactionMessage);
					switch (primaryInteraction.InteractionData.interactionType)
					{
						case InteractionType.Item :
							onInteraction?.Invoke(primaryInteraction.gameObject.GetComponent<Item>());
							break;
						case InteractionType.Door :
							primaryInteraction.OnInteraction();
							break;
						case InteractionType.OnOff :
							primaryInteraction.OnInteraction();
							break;
						case InteractionType.Teleport :
							primaryInteraction.OnInteraction();
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
		if (collision.gameObject.GetComponent<IInteractable>()?.CanActive == true)
		{
			interactables.Add(collision.GetComponent<IInteractable>());
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<IInteractable>()?.CanActive == true)
		{
			interactables.Remove(collision.GetComponent<IInteractable>());
		}
	}
}
