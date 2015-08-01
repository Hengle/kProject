using UnityEngine;
using System.Collections;

public class MeditationController : MonoBehaviour
{
	
	void Start () 
	{
		GameObject mdc_obj = GameObject.FindGameObjectWithTag("MasterData");
		MasterDataController mdc = null;
		if( mdc_obj != null )
		{
			mdc = mdc_obj.GetComponent<MasterDataController>();
			mdc.bMeditationDone = true;
		}
	}
	
	public void OnPress( int buttonID )
	{
		if (buttonID == 1) 
		{
			Application.LoadLevel ("MainMenu");
		}
	}
}