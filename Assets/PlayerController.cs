using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Transform cameraObj;
	public Transform heroObj;
	public Transform elevatorObj;

	private int speed = 5;
	private int jumpForce = 7;

	private bool isGrounded = false;

    private Animator anim;

	//winda
	private bool inElevator = false;
	private bool elevatorGoDown = false;
	private bool elevatorGoUp = false;

	private float camHeight;
	private float camWidth;

	// Use this for initialization
	void Start ()
	{			
		Camera cam = Camera.main;
		camHeight = cam.orthographicSize * 3.37f;
		camWidth = camHeight + cam.aspect;

		camWidth *= 0.8f;
	    anim = GetComponent<Animator>();
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
		} else if (Input.GetKeyDown ("s")) {
			elevatorGoDown = true;
		} else {
			elevatorGoDown = false;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, GetComponent<Rigidbody2D> ().velocity.y);
		}
		if (Input.GetKeyDown ("w") && isGrounded) {				
			if (inElevator) {
				// jest w windize
				elevatorGoUp = true;
			} else {
				//skok
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
				elevatorGoUp = false;
			}
		}

		//sterowanie dotykowe
		double touchScreenX = Screen.width / 4.0f;
		double touchScreenCenterY = Screen.height / 2.0f;

		double touchScreenLeft = touchScreenX;
		double touchScreenRight = touchScreenX * 3.0f;



		if (Input.touchCount > 0) {
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

			    if (myTouches[i].phase == TouchPhase.Began) {

			        if ((myTouches[i].position.x > touchScreenLeft) && (myTouches[i].position.x < touchScreenRight)) {
			            //skok/jazda w górę na górnej części ekranu
			            if ((myTouches[i].position.y > touchScreenCenterY) && isGrounded) {
			                if (inElevator) {
			                    // jest w windize
			                    elevatorGoUp = true;
			                }
			                else {
			                    //skok
			                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			                    elevatorGoUp = false;
			                }
			            }

			            //jazda w dół na windzie
			            if (myTouches[i].position.y < touchScreenCenterY) {
							elevatorGoUp = false;
			                elevatorGoDown = true;
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
        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
	}



	void OnTriggerEnter2D (Collider2D other)
	{				


	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.transform.tag == "Ground") {
			if (!isGrounded) {
				isGrounded = true;
			    anim.SetBool("Grounded", true);
			}
		}

		if ((other.transform.tag == "ElevatorTop") ||
			(other.transform.tag == "ElevatorBottom") || 
			(other.transform.tag == "ElevatorMiddle")){
			inElevator = true;
		}

		if (other.transform.tag == "ElevatorTop") {
			
			if (elevatorGoDown) {
				elevatorGoDown = false;
				other.transform.localPosition = new Vector3 (other.transform.localPosition.x, other.transform.localPosition.y - 0.6342f); //winda w dół
				this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y - 2.561f); //hans w dół
				other.transform.localPosition = new Vector3 (other.transform.localPosition.x, other.transform.localPosition.y + 0.6342f); //reset windy
				Debug.Log ("ElevatorTop w dół");
			}
		}

		if (other.transform.tag == "ElevatorBottom") {
			if (elevatorGoUp) {
				elevatorGoUp = false;
				other.transform.localPosition = new Vector3 (other.transform.localPosition.x, other.transform.localPosition.y + 0.6342f); //winda w dół
				this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y + 2.561f); //hans w dół
				other.transform.localPosition = new Vector3 (other.transform.localPosition.x, other.transform.localPosition.y - 0.6342f); //reset windy
				Debug.Log ("ElevatorBottom w górę");

			}
		}

		if (other.transform.tag == "ElevatorMiddle") {
			if (elevatorGoUp) {
				elevatorGoUp = false;
				other.transform.localPosition = new Vector3 (other.transform.localPosition.x, other.transform.localPosition.y + 0.6342f); //winda w dół
				this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y + 2.561f); //hans w dół
				other.transform.localPosition = new Vector3 (other.transform.localPosition.x, other.transform.localPosition.y - 0.6342f); //reset windy
				Debug.Log ("ElevatorMiddle w górę");
			}

			if (elevatorGoDown) {
				elevatorGoDown = false;
				other.transform.localPosition = new Vector3 (other.transform.localPosition.x, other.transform.localPosition.y - 0.6342f); //winda w dół
				this.transform.localPosition = new Vector3 (this.transform.localPosition.x, this.transform.localPosition.y - 2.561f); //hans w dół
				other.transform.localPosition = new Vector3 (other.transform.localPosition.x, other.transform.localPosition.y + 0.6342f); //reset windy
				Debug.Log ("ElevatorMiddle w dół");
			}
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.transform.tag == "Ground") {
			isGrounded = false;
			//Debug.Log ("not grounded!");
		}

		if ((other.transform.tag == "ElevatorTop") ||
			(other.transform.tag == "ElevatorBottom") || 
			(other.transform.tag == "ElevatorMiddle")){
			inElevator = false;
		}
	}
		
}
