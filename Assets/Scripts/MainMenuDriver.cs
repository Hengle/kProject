using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuDriver : MonoBehaviour 
{
	public Toggle m_JournalToggle;
	public Toggle m_AffirmationToggle;
	public Toggle m_MeditationToggle;


	static GameObject s_Data = null;
	static MasterDataController s_mdc = null;

	public Transform m_BackgroundUIAsset;

	public MasterDataController masterDataController;

	void Awake()
	{
		m_BackgroundUIAsset.gameObject.SetActive(false);
	}

	void Start () 
	{
		if (MasterDataController.instance == null) {
			Instantiate (masterDataController);
		}

		GameObject mdc_obj = GameObject.FindGameObjectWithTag ("MasterData");
		MasterDataController mdc = null;
		if (mdc_obj != null) 
		{
			s_mdc = mdc_obj.GetComponent<MasterDataController> ();
		}
	}

	void Update () 
	{ 
		// TODO: Maybe not update this every frame.. ??
		if (s_mdc != null) 
		{
			if (m_JournalToggle != null)
				m_JournalToggle.isOn = s_mdc.bJournalDone;
			if (m_AffirmationToggle != null)
				m_AffirmationToggle.isOn = s_mdc.bAffirmationDone;
			if (m_MeditationToggle != null)
				m_MeditationToggle.isOn = s_mdc.bMeditationDone;
		}
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
		} 
		else if (buttonID == 5) 
		{
			m_BackgroundUIAsset.gameObject.SetActive(true);
			var controller = new WaitController();
			StartCoroutine(FindPsychotherapist( 20.0f, controller ));
		} 
		else if (buttonID == 6) 
		{
			Application.LoadLevel ("Arm Yourself");
		} else if (buttonID == 7) {
			Application.LoadLevel ("Settings");
		} else if (buttonID == 8) {
			Application.LoadLevel ("About Us");
		}
	}

	public class WaitController
	{
		public bool cancel;
		public bool pause;
	}

	IEnumerator FindPsychotherapist(float timeToWait, WaitController controller)
	{
		if( !Input.location.isEnabledByUser )
		{
			// TODO : If IOS continue. if anything else popup saying to enable GPS

			m_BackgroundUIAsset.gameObject.SetActive(false);
			yield break;
		}

		Input.location.Start ();

		while(timeToWait > 0 && Input.location.status == LocationServiceStatus.Initializing )
		{
			if(!controller.pause)
				timeToWait -= Time.deltaTime;
			if(controller.cancel)
				yield break;
			yield return null;
		}

		if( Input.location.status == LocationServiceStatus.Failed )
		{
			// TODO: Tell the user that something happen with the GPS servicies.
			Debug.LogError("Unable to determine device location");
		}
		else
		{
			LocationInfo li = new LocationInfo();
			float lat = Input.location.lastData.latitude;
			float lon = Input.location.lastData.longitude;
			string Latlon = "@" + lat.ToString() + lon.ToString();
			m_BackgroundUIAsset.gameObject.SetActive(false);
			Input.location.Stop();
			Application.OpenURL ("https://www.google.com/maps/search/psychotherapist" + "/" + Latlon);
		}

		yield break;
	}
}
