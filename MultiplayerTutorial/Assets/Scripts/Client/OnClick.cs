using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnClick : MonoBehaviour {


	private static Vector3 moveToDestination = Vector3.zero;
	private static List<string> passabels = new List<string>() {"Floor"};


	public static Vector3 GetDestination()
	{
		if (moveToDestination == Vector3.zero){
		RaycastHit hit;
		Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(r, out hit))
			while (!passabels.Contains(hit.transform.gameObject.name))
			{
				if (!Physics.Raycast(hit.transform.position, r.direction, out hit))
					break;
			}
			moveToDestination = hit.point;
		}
		return moveToDestination;
	}
}
