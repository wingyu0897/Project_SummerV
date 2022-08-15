using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
	[SerializeField] Transform itemHolder;

	[SerializeField] private KeyCode changeItemKey;
	[SerializeField] private KeyCode dropItemKey;
	[SerializeField] Vector3 dropPosition;

	[SerializeField] private List<Item> items = new List<Item>();

	private int currentItemNum = 0;
	private ItemUse itemUse;

	private void Awake()
	{
		itemUse = transform.parent.GetComponent<ItemUse>();

		foreach (Item f in items)
		{
			if (f != null)
			{
				itemUse.PrimaryItem = f;
				break;
			}
		}
	}

	private void Start()
	{
		foreach (Item f in items)
		{
			if (f != null)
			{
				f.OnInteraction();
				f.gameObject.SetActive(false);
			}
		}
		items[0]?.gameObject.SetActive(true);
	}

	private void Update()
	{
		HandSwap();
	}

	private void HandSwap()
	{
		if (Input.GetKeyDown(changeItemKey))
		{
			items[currentItemNum]?.gameObject.SetActive(false);
			currentItemNum = currentItemNum == items.Count - 1 ? 0 : ++currentItemNum;

			items[currentItemNum]?.gameObject.SetActive(true);
			itemUse.PrimaryItem = items[currentItemNum] != null ? items[currentItemNum] : null;
		}
		if (Input.GetKeyDown(dropItemKey))
		{
			Drop();
		}
	}

	public void Drop()
	{
		if (itemUse.PrimaryItem != null)
		{
			items.Remove(itemUse.PrimaryItem);

			itemUse.PrimaryItem.transform.position = transform.position + dropPosition;
			itemUse.PrimaryItem.OnDrop();
			itemUse.PrimaryItem = null;
		}
	}

	public void PickUpItem(Item item)
	{
		item.transform.SetParent(itemHolder);
		item.OnInteraction();
		items.Add(item);
	}

	public void HandMove(Vector3 pointerPos)
    {
		transform.eulerAngles = pointerPos;
    }
}
