using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Item
{
	private bool isOn = true;
	[SerializeField] private ToolData flashLightData;
	public ToolData FlashLightData
	{
		get => flashLightData;
		set => flashLightData = value;
	}
	[SerializeField] private GameObject lights;

	public override void Init()
	{
		lights.SetActive(true);
	}

	public override void UseItem()
	{
		isOn = isOn ? false : true;
		lights.SetActive(isOn);
	}

	public override ToolData ReturnData()
	{
		return flashLightData;
	}
}
