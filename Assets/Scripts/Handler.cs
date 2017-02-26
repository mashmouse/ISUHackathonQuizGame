using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;

public class Handler : MonoBehaviour {
	public String [] promptTexts;
	public String [] responseTexts;

	public Image imageGo;

	Button [] buttons;// I use Awake here so that the buttons are initialized through the ButtomWork scripts.

	void Start () {
		buttons = GetComponentsInChildren<Button> ();
		if (buttons != null && buttons.Length == promptTexts.Length && buttons.Length == responseTexts.Length) {
			for (int i = 0; i < buttons.Length; i++) {
				print (buttons [i].name); // This is one nasty line of OO code. 
				// It says fetch the ButtonWork object from the current button.
				ButtonPressed bw = buttons [i].GetComponent<ButtonPressed> ();
				print (bw);
				//bw.startText = promptTexts [i];
				//bw.outputText = responseTexts [i];
			}
		}else { 
			Debug.Log ("This is why you don't use parallel arrays");
		}
	}

	public void Option1Pressed(){
		imageGo.sprite = Resources.Load<Sprite> ("spoon") as Sprite;
	}

	public void Option2Pressed(){
		imageGo.sprite = Resources.Load<Sprite> ("dog");
	}

	public void Option3Pressed(){
		imageGo.sprite = Resources.Load<Sprite> ("building");
	}

	public void Option4Pressed(){
		imageGo.sprite = Resources.Load<Sprite> ("bicycle");
	}
}
