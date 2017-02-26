using UnityEngine;
using System.Collections;

[System.Serializable]
public class RoundData 
{
	public string name; //name of the round
	public int timeLimitInSeconds; //time limit per round (we probably want to figure out how to NOT use this)
	public int pointsAdded; //when you get something right
	public QuestionData[] questions; //each round holds a number of questions
}
