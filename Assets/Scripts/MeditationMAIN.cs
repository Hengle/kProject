using UnityEngine;
using System.Collections;

public class MeditationMAIN : MonoBehaviour 
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
		if (buttonID == 2)
		{
			Application.LoadLevel ("Beg_Med");
		}
		if (buttonID == 3) 
		{
			Application.LoadLevel ("Gen_Med");
		}
		if (buttonID == 4) 
		{
			Application.LoadLevel ("Acc_Med");
		}
		if (buttonID == 5) 
		{
			Application.LoadLevel ("Clentch");
		}
		if (buttonID == 6) 
		{
			Application.LoadLevel ("SOS");
		}
		if (buttonID == 7) 
		{
			Application.LoadLevel ("Target");
		}
		if (buttonID == 8) 
		{
			Application.LoadLevel ("Warmth");
		}
	}
}