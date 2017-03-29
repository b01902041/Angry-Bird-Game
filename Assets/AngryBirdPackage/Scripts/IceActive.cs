using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceActive : MonoBehaviour {

	public static bool created2 = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void Awake ()
	{
		if (!created2) {
			DontDestroyOnLoad(this.gameObject);
			created2 = true;
		}

		else if (created2){
			Destroy(this.gameObject);
		}
	}
}
