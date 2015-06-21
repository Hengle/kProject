using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuDriver : MonoBehaviour 
{
	public Toggle mToggle;
	static GameObject s_Data = null;

	public MasterDataController masterDataController;

	void Start () 
	{
		if( MasterDataController.instance == null )
		{
			Instantiate(masterDataController);
		}

		GameObject mdc_obj = GameObject.FindGameObjectWithTag("MasterData");
		MasterDataController mdc = null;
		if( mdc_obj != null )
		{
			mdc = mdc_obj.GetComponent<MasterDataController>();
		}
		
		if ( mdc != null )
		{
			if(mToggle != null)
				mToggle.isOn = mdc.pJournalDone;
		}
	}

	void Update () 
	{
	}

	public void OnPress( int buttonID )
	{
		if (buttonID == 0) {
			Application.LoadLevel ("Journal");
		} else if (buttonID == 1) {
			Application.LoadLevel ("Meditation");
		} else if (buttonID == 2) {
			Application.LoadLevel ("Affirmation");
		} else if (buttonID == 3) {
			Application.LoadLevel ("Coping List");
		} else if (buttonID == 4) {
			Application.LoadLevel ("Progress");
		} else if (buttonID == 5) {
			Application.LoadLevel ("Find A Therapist");
		} else if (buttonID == 6) {
			Application.LoadLevel ("Arm Yourself");
		} else if (buttonID == 7) {
			Application.LoadLevel ("Settings");
		} else if (buttonID == 8) {
			Application.LoadLevel ("About Us");
		}

	}
}
