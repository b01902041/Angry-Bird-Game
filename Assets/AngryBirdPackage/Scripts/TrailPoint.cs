using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPoint : MonoBehaviour {

	public GameObject pointObj;
	public GameObject fix;
	public static bool bTrail = false;

	public float x1, y1;


	// Use this for initialization
	void Start () {
		x1 = this.transform.position.x;
		y1 = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (bTrail) {
			float x2 = this.transform.position.x;
			float y2 = this.transform.position.y;

			float distance = Mathf.Sqrt ((y2 - y1) * (y2 - y1) + (x2 - x1) * (x2 - x1));

			if (distance > 0.8f) {
				fix = Instantiate (pointObj, this.transform.position, Quaternion.identity);
				float scale = Random.Range (0.3f, 0.8f);
				fix.transform.localScale = new Vector3 (scale, scale, scale);
				x1 = this.transform.position.x;
				y1 = this.transform.position.y;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		bTrail = false;
	}

}
