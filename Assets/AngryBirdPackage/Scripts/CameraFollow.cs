using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform followObj;
	public Transform leftObj;
	public Transform rightObj;
	public Transform upObj;
	public Transform downObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x = followObj.position.x;
		newPosition.y = followObj.position.y;
		newPosition.x = Mathf.Clamp (newPosition.x, leftObj.position.x, rightObj.position.x);
		newPosition.y = Mathf.Clamp (newPosition.y, downObj.position.y, upObj.position.y);
		transform.position = newPosition;

		if (Input.GetAxis ("Mouse ScrollWheel") <= 0 && this.GetComponent<Camera> ().orthographicSize <= 10) {
			this.GetComponent<Camera> ().orthographicSize = this.GetComponent<Camera> ().orthographicSize - Input.GetAxis ("Mouse ScrollWheel");
		}
		else if (Input.GetAxis("Mouse ScrollWheel") >= 0 && this.GetComponent<Camera>().orthographicSize >= 8) {
			this.GetComponent<Camera> ().orthographicSize = this.GetComponent<Camera> ().orthographicSize - Input.GetAxis ("Mouse ScrollWheel");
		}
	}
}
