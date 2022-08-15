using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
	[SerializeField] private KeyCode useKey;
    [SerializeField] private Item primaryItem;
	public Item PrimaryItem { get => primaryItem; set => primaryItem = value; }

	private void Update()
	{
		if (Input.GetKeyDown(useKey))
		{
			primaryItem?.UseItem();
		}
	}
}
