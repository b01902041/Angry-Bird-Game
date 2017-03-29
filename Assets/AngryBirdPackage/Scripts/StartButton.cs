using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("resetTime", 0);
		Debug.Log (Resetter.resetTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void DestryButton() {
		GameObject.Destroy (this.gameObject);

	}
}
