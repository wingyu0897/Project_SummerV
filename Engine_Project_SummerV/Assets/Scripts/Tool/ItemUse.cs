using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    [SerializeField] private Item primaryItem;

	private void Awake()
	{
		primaryItem.Init();
	}

	private void Update()
	{
		KeyCode useKey = primaryItem.ReturnData().useKey;
		if (Input.GetKeyDown(useKey))
		{
			primaryItem.UseItem();
		}
	}
}
