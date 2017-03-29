using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodAction : MonoBehaviour {

	public static bool created = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake ()
	{
		if (!created) {
			DontDestroyOnLoad(this.gameObject);
			created = true;
		}

		else if (created){
			Destroy(this.gameObject);
		}
	}
}
