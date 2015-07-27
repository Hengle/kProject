using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashController : MonoBehaviour 
{
	public Image m_TitleImage;
	float m_Alpha = 0.0f;
	void Start()
	{
		StartCoroutine(WaitAndContinue(3f));
		Color col = m_TitleImage.color;
		col.a = 0;
		m_TitleImage.color = col;
	}

	void Update()
	{
		Color col = m_TitleImage.color;
		m_Alpha += (0.0009f) * Time.deltaTime;
		col.a = 255.0f * m_Alpha;
		m_TitleImage.color = col;
	}

	IEnumerator WaitAndContinue(float waitTime) 
	{
		// Wait 
		yield return new WaitForSeconds(waitTime);

		// Load level
		Application.LoadLevel("MainMenu");
	}
}
