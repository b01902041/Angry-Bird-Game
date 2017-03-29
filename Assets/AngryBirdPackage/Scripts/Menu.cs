using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public GameObject fix, _canvas;
	public GameObject bird;
	public GameObject _PlayButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (PlayerPrefs.GetString ("Mode") == "level") {
			_PlayButton.SetActive (false);
			PlayerPrefs.SetString ("Mode", " ");
			LevelBtn();
		}*/

		Object[] Objs = GameObject.FindGameObjectsWithTag ("FlyBird");
		int ran = Random.Range (0, 100);
		if (ran > 97 && Objs.Length < 3) {
			bird = Instantiate (Resources.Load ("FlyBird"), Vector3.zero, Quaternion.identity) as GameObject;
		}

	}
	public void PlayBtn() {
		//PlayerPrefs.SetString ("Mode", "level");
		Destroy (GameObject.Find ("Planks"));
		Destroy (GameObject.Find ("Items"));
		WoodAction.created = false;
		IceActive.created2 = false;
		TrailPoint.bTrail = false;
		SceneManager.LoadScene(1);
	}
	/*public void QuitBtn() {
		Application.Quit ();
	}*/
	/*void LevelBtn() {
		GameObject target = Resources.Load ("Locked") as GameObject;
		fix = Instantiate (target, Vector3.zero, Quaternion.identity) as GameObject;

		int Score = PlayerPrefs.GetInt ("Score");
		for (int i = 1; i <= (Score + 1); i++) {
			GameObject target2 = Resources.Load ("Level" + i) as GameObject;
			fix = Instantiate (target2, Vector3.zero, Quaternion.identity) as GameObject;

		}
	}*/
		
}
