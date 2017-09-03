using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public bool isDeactivated = false;
	public Sprite btnDeactSprite;
	public Sprite sensorDeactSprite;
	public GameObject sensor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//Debug.Log ("sensor triggered");
		if (other.name == "Hans")
		{
			isDeactivated = true;
			this.GetComponent<SpriteRenderer> ().sprite = btnDeactSprite;
			sensor.GetComponent<SpriteRenderer> ().sprite = sensorDeactSprite;
		}

	}
}
