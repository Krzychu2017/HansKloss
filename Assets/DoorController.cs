using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{

	public Text KeyCount;

	private int key;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		key = PlayerPrefs.GetInt ("KeyCount");
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (key > 0) {			
			key--;
			PlayerPrefs.SetInt("KeyCount", key);
			Destroy (gameObject);
		}
	}

}
