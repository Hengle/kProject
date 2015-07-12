using UnityEngine;
using System.Collections;

public class LoadingSpinnerController : MonoBehaviour
{
	void Update () 
	{
		Vector3 pos = gameObject.transform.position;
		gameObject.transform.RotateAround(pos, Vector3.forward, -5.0f);
	}
}
