using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;


public class ButtonPressed : MonoBehaviour {
	public bool correctButton;
	public String startText;

	Text[] textContent;
	Text text;

	// Use this for initialization
	void Start () {
		textContent = GetComponentsInChildren<Text> ();
		if (textContent != null && textContent.Length > 0){
			text = textContent[0];
			text.text = startText;
			//print("START: Text content of Button Exists as " + textContent[0].text + " (1) or not (0): " + textContent.Length);
		} else { print("Button contains more than one element or no elements.");}
	}


	public void ButtonPressedResponse(){
		if (correctButton) {
			print ("Correct");
		}
	}
}
