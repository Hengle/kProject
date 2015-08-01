using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AffirmationDriver : MonoBehaviour 
{
	public Text m_AffirmationText;
	public int CurrentAffirmationIndex;
	public string[] Affirmations;

	void Start () 
	{
		GameObject mdc_obj = GameObject.FindGameObjectWithTag("MasterData");
		MasterDataController mdc = null;
		if( mdc_obj != null )
		{
			mdc = mdc_obj.GetComponent<MasterDataController>();

			mdc.bAffirmationDone = true;

			if( mdc.CurrentAffirmationIndex >= Affirmations.Length )
				mdc.CurrentAffirmationIndex = 0;

			CurrentAffirmationIndex = mdc.CurrentAffirmationIndex;

			Debug.Log("mdc.CurrentAffirmationIndex " + mdc.CurrentAffirmationIndex );

			m_AffirmationText.text = Affirmations[mdc.CurrentAffirmationIndex];
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
