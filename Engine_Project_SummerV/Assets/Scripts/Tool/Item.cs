using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected virtual void Awake()
	{
		Init();
	}

    public abstract void Init();
    public abstract void UseItem();
	public abstract void OnDrop();
	public abstract void OnInteraction();
	public abstract ToolData ReturnData(); 
}
