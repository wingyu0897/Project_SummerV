using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentObstacle : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 7)
		{
			collision.gameObject.GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.5f);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 7)
		{
			collision.gameObject.GetComponent<Tilemap>().color = new Color(1, 1, 1, 1);
		}
	}
}
