using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

	public Image image;
	public Text questionDisplayText;
	public Text scoreDisplayText;
	public Text timeRemainingDisplayText;
	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject questionDisplay;
	public GameObject roundEndDisplay;

	private DataController dataController;
	private RoundData currentRoundData;
	private QuestionData[] questionPool;

	private bool isRoundActive;
	private float timeRemaining;
	private int questionIndex;
	private int playerScore;
	private List<GameObject> answerButtonGameObjects = new List<GameObject> ();

	// Use this for initialization
	void Start ()
	{
		dataController = FindObjectOfType<DataController> ();
		if (dataController == null) {
			print ("Couldn't find dataController");
			return;
		}
		currentRoundData = dataController.GetCurrentRoundData ();
		questionPool = currentRoundData.questions;
		timeRemaining = currentRoundData.timeLimitInSeconds;
		UpdateTimeRemainingDisplay ();

		playerScore = 0;
		questionIndex = 0;

		ShowQuestion ();
		isRoundActive = true;

	}

	private void ShowQuestion ()
	{
		
		print ("showing questions");
		RemoveAnswerButtons ();
		QuestionData currentQuestionData = questionPool [questionIndex];
		questionDisplayText.text = currentQuestionData.imageName;
		print (image);
		image.sprite = Resources.Load<Sprite> (currentQuestionData.imageName);

		List<string> incorrectAnswers = new List<string> ();
		Debug.Assert (questionPool.Length >= 4);
		while (incorrectAnswers.Count < 3) {
			string answer = questionPool [Random.Range (0, questionPool.Length)].answer;

			if (answer != currentQuestionData.answer &&
				!incorrectAnswers.Contains (answer)) {
				print (answer);
				incorrectAnswers.Add (answer);
			}
		}

		List<Answer> allAnswers = new List<Answer> ();
		Answer correctAnswer = new Answer ();
		correctAnswer.text = currentQuestionData.answer;
		correctAnswer.isCorrect = true;
		allAnswers.Add (correctAnswer);
		for (int i = 0; i < incorrectAnswers.Count; i++) {
			Answer incorrectAnswer = new Answer ();
			incorrectAnswer.text = incorrectAnswers [i];
			incorrectAnswer.isCorrect = false;
			allAnswers.Add (incorrectAnswer);
		}
		print (allAnswers.Count);
		Shuffle (allAnswers);
		print (allAnswers.Count);
		for (int i = 0; i < allAnswers.Count; i++) {
			AddAnswerButton (allAnswers [i].text, allAnswers [i].isCorrect);
		}
	}

	// http://stackoverflow.com/questions/5383498/shuffle-rearrange-randomly-a-liststring
	public static void Shuffle<T> (List<T> list)
	{
		int n = list.Count;
		while (n > 1) {
			int k = Random.Range (0, n) % n;
			n--;
			T value = list [k];
			list [k] = list [n];
			list [n] = value;
		}
	}


	private void AddAnswerButton (string text, bool isCorrect)
	{
		print (text);
		GameObject answerButtonGameObject = answerButtonObjectPool.GetObject ();
		answerButtonGameObjects.Add (answerButtonGameObject);
		answerButtonGameObject.transform.SetParent (answerButtonParent);

		AnswerButton answerButton = answerButtonGameObject
			.GetComponent<AnswerButton> ();
		answerButton.Setup (text, isCorrect);
	}

	private void RemoveAnswerButtons ()
	{
		while (answerButtonGameObjects.Count > 0) {
			answerButtonObjectPool.ReturnObject (answerButtonGameObjects [0]);
			answerButtonGameObjects.RemoveAt (0);
		}
	}

	public void AnswerButtonClicked (bool isCorrect)
	{
		if (isCorrect) {
			print (currentRoundData.pointsAdded);
			playerScore += currentRoundData.pointsAdded;
		}
		scoreDisplayText.text = "Score: " + playerScore.ToString () +
			" out of " + (1+ questionIndex).ToString ();
		if (questionPool.Length > questionIndex + 1) {
			questionIndex++;
			ShowQuestion ();
		} else {
			EndRound ();
		}

	}

	public void EndRound ()
	{
		isRoundActive = false;

		questionDisplay.SetActive (false);
		roundEndDisplay.SetActive (true);
	}

	public void ReturnToMenu ()
	{
		SceneManager.LoadScene ("MenuScreen");
	}

	private void UpdateTimeRemainingDisplay ()
	{
		timeRemainingDisplayText.text = "Time: " +
			Mathf.Round (timeRemaining).ToString ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (isRoundActive) {
			timeRemaining -= Time.deltaTime;
			UpdateTimeRemainingDisplay ();

			if (timeRemaining <= 0f) {
				EndRound ();
			}

		}
	}
}

class Answer
{
	public string text;
	public bool isCorrect;
}
