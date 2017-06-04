using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Transform cameraObj;
	public Transform heroObj;

	private int speed = 5;
	private int jumpForce = 7;

	private bool IsGrounded = false;

	private float camHeight;
	private float camWidth;

	// Use this for initialization
	void Start ()
	{			
		Camera cam = Camera.main;
		camHeight = cam.orthographicSize * 3.37f;
		camWidth = camHeight + cam.aspect;

		camWidth *= 0.9f;
	}

	bool isGrounded ()
	{
		
		if (GetComponent<Rigidbody2D> ().velocity.y > 0) {
			return false;
		} else {
			return true;
		}
	}

	// Update is called once per frame
	void Update ()
	{	
		Vector3 camPos = Camera.main.WorldToViewportPoint (transform.position);
		Vector3 camPosToInne = cameraObj.transform.position;
		Vector3 camOffset;

		//sterowanie klawiaturą
		if (Input.GetKey ("a")) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
			heroObj.transform.eulerAngles = new Vector3 (0, 180, 0);
		} else if (Input.GetKey ("d")) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
			heroObj.transform.eulerAngles = new Vector3 (0, 0, 0);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (Input.GetKeyDown (KeyCode.Space) && IsGrounded) {				
			//skok
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
		}

		//sterowanie dotykowe
		double touchScreenX = Screen.width / 4.0;
		double touchScreenLeft = touchScreenX;
		double touchScreenRight = touchScreenX * 3;

		if (Input.touchCount > 0) {
			//Touch myTouch = Input.GetTouch (0);

			Touch[] myTouches = Input.touches;
			for (int i = 0; i < Input.touchCount; i++) {
				if (myTouches [i].position.x < touchScreenLeft) {
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
					heroObj.transform.eulerAngles = new Vector3 (0, 180, 0);
				} else if (myTouches [i].position.x > touchScreenRight) {
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
					heroObj.transform.eulerAngles = new Vector3 (0, 0, 0);
				} 

				//zatrzymaj jeżeli podniesiono palce od chodzenia
				if (myTouches [i].phase == TouchPhase.Ended) {
					if ((myTouches [i].position.x < touchScreenLeft) || (myTouches [i].position.x > touchScreenRight)) {
						GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
					}
				}

				if (myTouches [i].phase == TouchPhase.Began) {
				
					if ( (myTouches [i].position.x > touchScreenLeft) && (myTouches [i].position.x < touchScreenRight) ) {
						if (IsGrounded) {
							GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
						}
					}
				}
			}

		}

		//pozycja kamery
		if (camPos.x < 0.0) {
//			Debug.Log ("I am left of the camera's view.");
			camOffset = new Vector3 (-camWidth, 0);
			cameraObj.transform.position = camPosToInne + camOffset;
		}
		if (1.0 < camPos.x) {
//			Debug.Log ("I am right of the camera's view.");
			camOffset = new Vector3 (camWidth, 0);
			cameraObj.transform.position = camPosToInne + camOffset;
		}
		if (camPos.y < 0.0) {
//			Debug.Log ("I am below the camera's view.");
			camOffset = new Vector3 (0, -camHeight / 2);
			cameraObj.transform.position = camPosToInne + camOffset;
		}
		if (1.0 < camPos.y) {
			//Debug.Log ("I am above the camera's view.");
			camOffset = new Vector3 (0, camHeight / 2);
			cameraObj.transform.position = camPosToInne + camOffset;
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{		
		if (other.transform.tag == "Ground") {
			IsGrounded = true;
//			Debug.Log ("Grounded!");
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.transform.tag == "Ground") {
			IsGrounded = false;
//			Debug.Log ("not grounded!");
		}
	}
}
