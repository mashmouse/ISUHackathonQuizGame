using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
	public RoundData allRoundData;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad (gameObject); //this keeps info from being destroyed when we change scenes

		SceneManager.LoadScene ("MenuScreen"); //loading our menu
	}

	public RoundData GetCurrentRoundData () //This supplies data about our round
	{
		return allRoundData; //We are only going to have data at index zero, in this case. in the future, we can pass this an int to tell us what round we’re in.
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
