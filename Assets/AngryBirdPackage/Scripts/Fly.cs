using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float Mx = Random.Range (-15f, 5f);
		transform.position = new Vector3 (Mx, -8, 0);
		float Vx = Random.Range (5f, 10f);
		float Vy = Random.Range (8f, 15f);
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Vx, Vy);
		StartCoroutine (WaitAndDestroy ());

	}

	IEnumerator WaitAndDestroy() {
		yield return new WaitForSeconds (5);
		Destroy (this.gameObject);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
