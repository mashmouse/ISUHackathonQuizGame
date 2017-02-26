using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

	public Text text;
	public bool isCorrect;

	private GameController gameController;

	// Use this for initialization
	void Start () 
	{
		gameController = FindObjectOfType<GameController> ();
	}

	public void Setup(string text, bool isCorrect)
	{
		this.text.text = text;
		this.isCorrect = isCorrect;
	}

	public void HandleClick()
	{
		gameController.AnswerButtonClicked (isCorrect);
	}
}