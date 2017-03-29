using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDamage : MonoBehaviour {

	public int hitPoints = 1;
	public float damageMinSpeed = 3;

	private int currentHitPoints;
	private float damageMinSpeedSqr;
	private SpriteRenderer _spriteRenderer;


	// Use this for initialization
	void Start () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		currentHitPoints = hitPoints;
		damageMinSpeedSqr = damageMinSpeed * damageMinSpeed;
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

		currentHitPoints--;

		if (currentHitPoints <= 0) {
			Kill ();
		}
	}

	void Kill() {
		_spriteRenderer.enabled = false;
		GetComponent<Collider2D> ().enabled = false;
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Kinematic;
		GetComponent<AudioSource>().Play ();
	}


}
