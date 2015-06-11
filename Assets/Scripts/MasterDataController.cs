using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DB = UnityEngine.Debug;
using Pathfinding.Serialization.JsonFx;
using System;
using System.IO;
using System.Text;

[Serializable]
[JsonName("Person")]
public class Person
{
	public string name;
	public string surname;
}

[JsonName("Animal")]
public class Animal
{
	public string name;
	public string species;
}

[Serializable]
public class Parameters
{
	public float floatValue;
	public string stringValue;
	public List<Person> listValue;
}


public class MasterDataController : MonoBehaviour {

	public static MasterDataController instance = null;
	public bool pJournalDone = false; 

	string _levelFile = "save.json";

	Dictionary<string, object> parameters = new Dictionary<string, object>();

	void Awake()
	{
		if( instance == null )
			instance = this;
		else if( instance != this )
			Destroy( gameObject );

		//pJournalDone = true;

		DontDestroyOnLoad(gameObject);

	}

	void Start () 
	{

		if ( LoadFromDisk() == false )
		{
	//		List<Person> persons = new List<Person>();
	//		persons.Add(new Person() { name = "Clayton", surname = "Curmi" });
	//		persons.Add(new Person() { name = "Karen", surname = "Attard" });
	//		
	//		List<Animal> animals = new List<Animal>();
	//		animals.Add(new Animal() { name = "Chimpanzee", species = "Pan troglodytes" });
	//		animals.Add(new Animal() { name = "Cat", species = "Felis catus" });
		
			parameters.Add("floatValue", 3f);
			parameters.Add("stringValue", "Parameter string info");
	//		parameters.Add("persons", persons.ToArray());
	//		parameters.Add("animals", animals.ToArray());
		}

	}

	void Update () 
	{
	
	}
		
	// ---- SERIALIZATION ----
	void SaveToDisk()
	{
		StreamWriter sw = File.CreateText(_levelFile);

		JsonWriterSettings writerSettings = new JsonWriterSettings();
		writerSettings.TypeHintName = "__type";
		
		StringBuilder json = new StringBuilder();
		JsonWriter writer = new JsonWriter(json, writerSettings);
		writer.Write(parameters);
		
		sw.Write(json);
		sw.Close();
		
		Debug.Log("jsonFile " + json.ToString());
	}

	// ---- DESERIALIZATION ----
	bool LoadFromDisk ()
	{
		if (!File.Exists(_levelFile)) 
		{
			return false;
		}

		StreamReader sr = File.OpenText(_levelFile);
		return false;

		string n_json = "";
		n_json = sr.ReadToEnd();
		
		JsonReaderSettings readerSettings = new JsonReaderSettings();
		readerSettings.TypeHintName = "__type";
		
		JsonReader reader = new JsonReader(n_json.ToString(), readerSettings);
		
		parameters = null;
		parameters = (Dictionary<string, object>)reader.Deserialize();

		// Debug output.
		foreach (KeyValuePair<string, object> kvp in parameters)
		{
			string key = kvp.Key;
			object val = kvp.Value;
			Debug.Log(string.Format("Key : {0}, Value : {1}, Type : {2}", key, val, val.GetType()));
		}

		return true;
	}
}
