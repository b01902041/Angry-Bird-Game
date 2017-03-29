using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

	public void Level_1() {
		SceneManager.LoadScene(1);

	}
	public void Level_2() {
		SceneManager.LoadScene(2);

	}

}
