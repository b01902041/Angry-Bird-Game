using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour {
	private Text result_text; 

	// Use this for initialization
	void Start () {
		result_text = this.GetComponent<Text>();
		result_text.enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}


	public void DisplayResult(string result) {
		result_text.enabled = true;
		if (result == "lose") {
			result_text.text = "You Lose! Please reset the game!";
		} else {
			result_text.text = "You Win!";
		}
	}
}
