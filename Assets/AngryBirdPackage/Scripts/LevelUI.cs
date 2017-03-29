using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Reset(){
		Resetter.resetTime = 0;
		TrailPoint.bTrail = false;
		Destroy (GameObject.Find ("Planks"));
		WoodAction.created = false;

		Destroy (GameObject.Find ("Items"));
		IceActive.created2 = false;

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	
	}
	public void Level(){
		//PlayerPrefs.SetString ("Mode", "level");
		SceneManager.LoadScene(0);
	
	}
	public void Menu(){
		Resetter.resetTime = 0;
		//PlayerPrefs.SetString ("Mode", " ");
		Destroy (GameObject.Find ("Planks"));
		Destroy (GameObject.Find ("Items"));
		SceneManager.LoadScene(0);
	}
		
}
