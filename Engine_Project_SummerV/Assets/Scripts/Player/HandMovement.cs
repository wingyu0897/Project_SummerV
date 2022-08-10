using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
	public void HandMove(Vector3 pointerPos)
    {
		transform.eulerAngles = pointerPos;
    }
}
