using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
	public GameObject player;

	[SerializeField] private TextMeshProUGUI interactionText;

	public Item primaryItem;

	private Sequence seq;

	private bool isPowerOn = false;
	public bool IsPowerOn
	{
		get => isPowerOn;
		set => isPowerOn = value;
	}

	private void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("ERROR: MultiGameManagerPlaying");
		}
		else
		{
			Instance = this;
		}
	}

	public void PopText(string message)
	{
		seq.Kill();
	
		interactionText.text = message;
		interactionText.transform.position = Camera.main.WorldToScreenPoint(player.transform.position - new Vector3(0, 2f));
		interactionText.color = new Color(1, 1, 1, 1);

		seq = DOTween.Sequence();
		seq.Append(interactionText.transform.DOMoveY(200, 0.5f).SetEase(Ease.Linear));
		seq.AppendInterval(1.0f);
		seq.Append(interactionText.DOFade(0, 1));
	}
}
