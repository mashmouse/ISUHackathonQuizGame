using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour {

	public void StartGame() //public function
	{
		SceneManager.LoadScene("Game"); //uses scenemanager to load Game.
		//This is called from our startbutton
	}
}
