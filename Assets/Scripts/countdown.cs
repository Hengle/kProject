
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countdown : MonoBehaviour {
	
	public float counter = 600.0f;  // declare a float and et to 30 to begin with for the max values
	private Slider mySlider;  // declare a slider object
	
	// Use this for initialization
	void Start () {
		// set reference to slider
		mySlider = GetComponent<Slider>();
		mySlider.maxValue = counter;
		mySlider.value = counter;
	}
	
	// Update is called once per frame
	void Update () {
		// decrement counter float with time it takes to draw each frame if its above 0;
		if (counter > float.Epsilon)
		{
			counter-= Time.deltaTime;
		}
		else
		{
			// if the values so low, just set to 0
			counter = 0;
		}
		// set the sliders value to counter value
		mySlider.value = counter;
		
		if (counter == 0)
		{
			Debug.Log("do something cos counter is 0");
		}
	}
}