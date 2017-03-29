using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	private SpringJoint2D spring;
	private bool bClick;
	private Rigidbody2D rigidbody2D = null;
	private Transform catapult;
	private Ray rayToMouse;
	private Vector2 preSpeed;
	public LineRenderer catapultsprite_0;
	public LineRenderer catapultsprite_1;
	private Ray catapultsprite_1ToStone;
	private float circleRadius;
	public AudioSource shootSound;

	void Awake () {
		spring = GetComponent<SpringJoint2D> ();
		catapult = spring.connectedBody.transform;

	}

	// Use this for initialization
	void Start () {
		rigidbody2D = this.GetComponent<Rigidbody2D> ();
		rayToMouse = new Ray (catapult.position, Vector3.zero);
		rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
		LineRendererSet ();
		catapultsprite_1ToStone = new Ray (catapultsprite_1.transform.position, Vector3.zero);
		CircleCollider2D circle = GetComponent<CircleCollider2D> ();
		circleRadius = circle.radius;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (bClick) {
			Dragging ();
		}
		if (spring != null) {
			if (rigidbody2D.bodyType != RigidbodyType2D.Kinematic && preSpeed.sqrMagnitude > rigidbody2D.velocity.sqrMagnitude) {
				rigidbody2D.velocity = preSpeed;
				Destroy (spring);
				TrailPoint.bTrail = true;
			}
			if (!bClick) {
				preSpeed = rigidbody2D.velocity;
			}
			LineRendererUpdate ();
		} else {
			catapultsprite_0.enabled = false;
			catapultsprite_1.enabled = false;
		}
	}

	void LineRendererSet (){
		catapultsprite_0.SetPosition (0, catapultsprite_0.transform.position);
		catapultsprite_0.sortingLayerName = "Line0";
		catapultsprite_0.sortingOrder = 0;

		catapultsprite_1.SetPosition (0, catapultsprite_1.transform.position);
		catapultsprite_1.sortingLayerName = "Line1";
		catapultsprite_1.sortingOrder = 0;
	}

	void LineRendererUpdate (){
		Vector2 catapultToStone = transform.position - catapultsprite_1.transform.position;
		catapultsprite_1ToStone.direction = catapultToStone;
		Vector3 thePoint = catapultsprite_1ToStone.GetPoint (catapultToStone.magnitude + circleRadius);

		catapultsprite_0.SetPosition (1, thePoint);
		catapultsprite_1.SetPosition (1, thePoint);

	}


	void OnMouseDown () {
		
		spring.enabled = false;
		bClick = true;

	}

	void OnMouseUp () {
		
		spring.enabled = true;
		bClick = false;
		rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
		shootSound.Play ();
	}

	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;

		if (catapultToMouse.sqrMagnitude > 9.0f) {
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint (3.0f);
		}
		mouseWorldPoint.z = 0;
		transform.position = mouseWorldPoint;
	}
}
