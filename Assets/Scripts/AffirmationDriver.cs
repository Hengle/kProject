using UnityEngine;
using System.Collections;

public class AffirmationController : MonoBehaviour 
{
	
	void Start () 
	{
		GameObject mdc_obj = GameObject.FindGameObjectWithTag("MasterData");
		MasterDataController mdc = null;
		if( mdc_obj != null )
		{
			mdc = mdc_obj.GetComponent<MasterDataController>();
		}

		if ( mdc != null )
			mdc.pJournalDone = true;
	}
	
	public void OnPress( int buttonID )
	{
		if (buttonID == 1) {
			Application.LoadLevel ("MainMenu");
		}
	
	// Update is called once per frame
//	void Update () {
		
	}
}
