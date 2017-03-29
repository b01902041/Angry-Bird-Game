using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdDamage : MonoBehaviour {

	public int hitPoints = 2;
	public Sprite diePicture;
	public float damageMinSpeed;

	private int currentHitPoints;
	private float damageMinSpeedSqr;
	private SpriteRenderer _spriteRenderer;
	public ScoreManager scoreManager;
	public ResultText resultText;
	// Use this for initialization
	void Start () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		currentHitPoints = hitPoints;
		damageMinSpeedSqr = damageMinSpeed * damageMinSpeed;
		//Resetter.resetTime = 0;
		//PlayerPrefs.SetInt ("resetTime", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.collider.tag != "Damager") {
			return;
		}
		if (collision.relativeVelocity.sqrMagnitude < damageMinSpeedSqr) {
			return;
		}
		_spriteRenderer.sprite = diePicture;
		currentHitPoints--;

		if (currentHitPoints <= 0) {
			Kill ();
		}
	}

	void Kill() {
		GetComponent<AudioSource>().Play ();
		_spriteRenderer.enabled = false;
		GetComponent<Collider2D> ().enabled = false;
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Kinematic;
		GetComponent<ParticleSystem> ().Play();

		resultText.DisplayResult ("win");

		//Destroy(GameObject.Find ("Planks"));
		StartCoroutine (WaitToLevel (SceneManager.GetActiveScene().buildIndex + 1));
		Resetter.resetTime = 0;


		//PlayerPrefs.SetInt ("Score", Application.loadedLevel);
	}
	IEnumerator WaitToLevel(int level) {
		//PlayerPrefs.SetString ("Mode", "level");
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene (level);


	}

}
