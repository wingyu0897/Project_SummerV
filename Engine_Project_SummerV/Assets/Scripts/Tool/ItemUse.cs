using TMPro;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
	[SerializeField] private KeyCode useKey;
    [SerializeField] private Item primaryItem;
	[SerializeField] private TextMeshProUGUI primaryItemText;
	public Item PrimaryItem { get => primaryItem; set => primaryItem = value; }

	private void Update()
	{
		primaryItemText.text = primaryItem?.gameObject.name ?? "None";
		GameManager.Instance.primaryItem = this.primaryItem;
		if (Input.GetKeyDown(useKey))
		{
			primaryItem?.UseItem();
		}
	}
}
