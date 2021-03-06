﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DB = UnityEngine.Debug;
using Pathfinding.Serialization.JsonFx;
using System;
using System.IO;
using System.Text;

[Serializable]
[JsonName("SaveData")]
public class SaveData
{
	public bool bOne;
	public string theString;
}

//[Serializable]
//[JsonName("Person")]
//public class Person
//{
//	public string name;
//	public string surname;
//}
//
//[JsonName("Animal")]
//public class Animal
//{
//	public string name;
//	public string species;
//}
//
//[Serializable]
//public class Parameters
//{
//	public float floatValue;
//	public string stringValue;
//	public List<Person> listValue;
//}


public class MasterDataController : MonoBehaviour 
{
	public static MasterDataController instance = null;

	// Main Data
	public bool bJournalDone 	= false; 
	public bool bMeditationDone = false;
	public bool bAffirmationDone = false;
	public int  CurrentAffirmationIndex = 0;

	string _levelFile = "save.json";

	Dictionary<string, object> parameters = new Dictionary<string, object>();

	//----------------------------------------------------------------------
	void Awake()
	{
		if( instance == null )
			instance = this;
		else if( instance != this )
			Destroy( gameObject );

		DontDestroyOnLoad(gameObject);
	}

	//----------------------------------------------------------------------
	void Start () 
	{
		if ( LoadFromDisk() == false )
		{
	//		List<Person> persons = new List<Person>();
	//		persons.Add(new Person() { name = "Clayton", surname = "Curmi" });
	//		persons.Add(new Person() { name = "Karen", surname = "Attard" });
	//		List<Animal> animals = new List<Animal>();
	//		animals.Add(new Animal() { name = "Chimpanzee", species = "Pan troglodytes" });
	//		animals.Add(new Animal() { name = "Cat", species = "Felis catus" });
	//		parameters.Add("stringValue", "Parameter string info");
	//		parameters.Add("persons", persons.ToArray());
	//		parameters.Add("animals", animals.ToArray());

			SaveToDisk();
		}

		int currDayOfYear = System.DateTime.Now.DayOfYear;
		int savedDayOfYear = (int)parameters["DayOfYear"];

		bJournalDone = (bool)parameters["bJournalDone"];
		bMeditationDone = (bool)parameters["bMeditationDone"];
		bAffirmationDone = (bool)parameters["bAffirmationDone"];
		CurrentAffirmationIndex = (int)parameters["CurrentAffirmationIndex"];

		if( savedDayOfYear != currDayOfYear )
		{
			Debug.Log ("New Day");

			// Reset Data for the day.
			bJournalDone = false;
			bMeditationDone = false;
			bAffirmationDone = false;
			CurrentAffirmationIndex++;
		}
		else
		{
			Debug.Log ("Same Day Detected current" + currDayOfYear + " saved:" + savedDayOfYear);
		}
	}

	//----------------------------------------------------------------------
	void Update () 
	{
	
	}

	//----------------------------------------------------------------------
	void OnApplicationQuit() 
	{
		SaveToDisk();
	}

	//----------------------------------------------------------------------
	void OnApplicationFocus(bool focusStatus) 
	{
		if( focusStatus == false )
			SaveToDisk();
	}

	//----------------------------------------------------------------------
	// ---- SERIALIZATION ----
	//----------------------------------------------------------------------
	void SaveToDisk()
	{
		string dataPath = Application.persistentDataPath;
		string loadFile = dataPath + _levelFile;

		Debug.Log(loadFile);

		StreamWriter sw = File.CreateText(loadFile);

		JsonWriterSettings writerSettings = new JsonWriterSettings();
		writerSettings.TypeHintName = "__type";
		
		StringBuilder json = new StringBuilder();
		JsonWriter writer = new JsonWriter(json, writerSettings);

		// Data

		int dayOfYear = System.DateTime.Now.DayOfYear;
		parameters.Clear();
		List<SaveData> saveData = new List<SaveData>();
		saveData.Add(new SaveData(){ bOne = false, theString = "string123" });
		parameters.Add ( "saveData", saveData.ToArray() ); 
		parameters.Add("Version", 0.1f);
		parameters.Add("bJournalDone", bJournalDone);
		parameters.Add("bMeditationDone", bMeditationDone);
		parameters.Add("bAffirmationDone", bAffirmationDone);
		parameters.Add("DayOfYear", dayOfYear);
		parameters.Add("CurrentAffirmationIndex", CurrentAffirmationIndex );

		// End Data

		writer.Write(parameters);
		
		sw.Write(json);
		sw.Close();
		
		Debug.Log("jsonFile " + json.ToString());
	}

	//----------------------------------------------------------------------
	// ---- DESERIALIZATION ----
	//----------------------------------------------------------------------
	bool LoadFromDisk ()
	{
		string dataPath = Application.persistentDataPath;
		string loadFile = dataPath + _levelFile;
		Debug.Log(loadFile);

		if (!File.Exists(loadFile)) 
		{
			return false;
		}

		StreamReader sr = File.OpenText(loadFile);

		string n_json = "";
		n_json = sr.ReadToEnd();
		
		JsonReaderSettings readerSettings = new JsonReaderSettings();
		readerSettings.TypeHintName = "__type";
		
		JsonReader reader = new JsonReader(n_json.ToString(), readerSettings);

		parameters.Clear();
		parameters = (Dictionary<string, object>)reader.Deserialize();

		if( parameters == null )
		{
			sr.Close();
			return false;
		}

		// Debug output.
//		foreach (KeyValuePair<string, object> kvp in parameters)
//		{
//			string key = kvp.Key;
//			object val = kvp.Value;
//			Debug.Log(string.Format("Key : {0}, Value : {1}, Type : {2}", key, val, val.GetType()));
//		}

		sr.Close();

		return true;
	}
}
