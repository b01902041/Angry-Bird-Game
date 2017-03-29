using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour {

	public Rigidbody2D Stone;
	public float resetSpeed = 0.05f;
	public SpringJoint2D spring;

	public static int resetTime = 0;
	public ScoreManager scoreManager;
	public ResultText resultText;
	// Use this for initialization
	void Start () {
		//Debug.Log (resetTime);
		spring = Stone.GetComponent<SpringJoint2D> ();
		//PlayerPrefs.SetInt ("resetTime", PlayerPrefs.GetInt ("resetTime") + 1);
		resetTime++;
		scoreManager.LifeDown ();
		Debug.Log (resetTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (spring == null && Stone.velocity.sqrMagnitude < resetSpeed * resetSpeed) {
			
			StartCoroutine (WaitAndReset ());

		}
	}

	IEnumerator WaitAndReset() {
		if (resetTime < 3) {
			TrailPoint.bTrail = false;
			yield return new WaitForSeconds (1);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		
		} else {
			scoreManager.LifeZero ();
			resultText.DisplayResult ("lose");
		}

	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.GetComponent<Rigidbody2D> () == Stone) {
			
			StartCoroutine (WaitAndReset ());


		}
	}
}
