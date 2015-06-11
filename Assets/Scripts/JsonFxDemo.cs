using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DB = UnityEngine.Debug;
using Pathfinding.Serialization.JsonFx;
using System;
using System.IO;

//[System.Serializable]
//public class Level
//{
//	public string LevelName;
//	public string Id;
//	public int    Number;
//	public float  FloatNumber;
//	public bool   bIsTrue;
//}
//
//public class JsonFxDemo : MonoBehaviour 
//{
//	string _levelFile = "levels.json";
//	public Level level;
//
//	// Use this for initialization
//	void Start () 
//	{
//		StreamWriter sw = File.CreateText(_levelFile);
//
//		JsonWriterSettings settings = new JsonWriterSettings();
//		settings.PrettyPrint = true;
//		settings.AddTypeConverter (new VectorConverter());
//
//		System.Text.StringBuilder output = new System.Text.StringBuilder();
//
//		JsonWriter writer = new JsonWriter( output, settings );
//
//		writer.Write(level);
//
//		sw.Write(output);
//		sw.Close();
//	}
//}

public class VectorConverter : JsonConverter 
{
	public override bool CanConvert (Type t) 
	{
		return t == typeof(Vector3);
	}
	
	public override Dictionary<string,object> WriteJson (Type type, object value) 
	{
		Vector3 v = (Vector3)value;
		Dictionary<string,object> dict = new Dictionary<string, object>();
		dict.Add ("x",v.x);
		dict.Add ("y",v.y);
		dict.Add ("z",v.z);
		return dict;
	}
	
	public override object ReadJson (Type type, Dictionary<string,object> value) 
	{
		Vector3 v = new Vector3(CastFloat(value["x"]),CastFloat(value["y"]),CastFloat(value["z"]));
		return v;
	}
}
