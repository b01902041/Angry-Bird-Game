using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text life_text; 
	const string LifePrefix = "Life : "; 

	// Use this for initialization
	void Start () {
		life_text = this.GetComponent<Text>();
		life_text.text = LifePrefix + (3 - Resetter.resetTime + 1); 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LifeDown() { 
		life_text.text = LifePrefix + (3 - Resetter.resetTime + 1); 
	} 
	public void LifeZero() { 
		life_text.text = LifePrefix + (3 - Resetter.resetTime); 
	} 
		

}
