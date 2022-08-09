using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
	private bool isOn = true;
	
	[SerializeField] private KeyCode switchKey;

	[SerializeField] private GameObject lights;

	private void Update()
	{
		
	}

	private void Execution()
	{
		if (Input.GetKeyDown(switchKey))
		{
			isOn = !isOn;
		}
		lights?.SetActive(isOn);
	}

	private void Init()
	{
		lights?.SetActive(true);
	}
}
