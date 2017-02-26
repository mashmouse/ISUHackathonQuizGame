using UnityEngine;
using System.Collections;

[System.Serializable] //should we change this to be MonoBehavior  so that we can use ifs and stuff? I don't think we need it to be changed in the inspector screen.
public class QuestionData 
{
	public string imageName;
	public string answer;
}