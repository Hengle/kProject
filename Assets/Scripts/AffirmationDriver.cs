I know..using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AffirmationDriver : MonoBehaviour 
{
	public Text m_AffirmationText;
	public string[] Affirmations;

	[Header("Debug")]
	public int CurrentAffirmationIndex;

	private MasterDataController mdc = null;

	void Start () 
	{
		GameObject mdc_obj = GameObject.FindGameObjectWithTag("MasterData");
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

	void Update()
	{
		m_AffirmationText.text = Affirmations[CurrentAffirmationIndex];
	}

	public void OnPress( int buttonID )
	{
		if (buttonID == 1) 
		{
			Application.LoadLevel ("MainMenu");
		}
	}
}
