using UnityEngine;
using System.Collections;

public class SplashController : MonoBehaviour 
{
	void Start()
	{
		StartCoroutine(WaitAndContinue(5.0F));
	}

	IEnumerator WaitAndContinue(float waitTime) 
	{
		// Wait 
		yield return new WaitForSeconds(waitTime);

		// Load level
		Application.LoadLevel("MainMenu");
	}
}
