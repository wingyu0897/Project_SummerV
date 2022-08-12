using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class TilemapTransparent : MonoBehaviour
{
	[SerializeField] Tilemap tilemap;
	[SerializeField] CircleCollider2D circleCollider;
	[SerializeField] LayerMask tilemapLayer;
	[Tooltip("CircleCollider의 Radius보다 작게")]
	[SerializeField][Range(0, 10)] float distance = 3;
	[SerializeField] float setTransparent = 0.7f;

	private void Awake()
	{
		circleCollider = GetComponent<CircleCollider2D>();
	}

	private void Update()
	{
		Range();
	}

	private void Range()
	{
		int radiusInt = Mathf.RoundToInt(circleCollider.radius);
		for (int i = -radiusInt; i <= radiusInt; i++)
		{
			for (int j = -radiusInt; j <= radiusInt; j++)
			{
				Vector3 checkCellPos = new Vector3(transform.position.x + i, transform.position.y + j);
				float cellDistance = Vector2.Distance(transform.position, checkCellPos);

				if (cellDistance <= distance)
				{
					Collider2D overCollider = Physics2D.OverlapCircle(checkCellPos, 0.01f);
					if (overCollider != null)
					{
						Transparent(checkCellPos, setTransparent);
					}
				}
				else if (cellDistance > distance)
				{
					Collider2D overCollider = Physics2D.OverlapCircle(checkCellPos, 0.01f);
					if (overCollider != null)
					{
						Transparent(checkCellPos, 1f);
					}
				}
			}
		}
	}

	private void Transparent(Vector3 position, float alpha)
	{
		Vector3Int cellPosition = tilemap.WorldToCell(position);

		tilemap.SetTileFlags(cellPosition, TileFlags.None);
		tilemap.SetColor(cellPosition, new Color(1, 1, 1, alpha));
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		if (UnityEditor.Selection.activeObject == gameObject)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, distance);
			Gizmos.color = Color.white;
		}
	}
#endif
}
