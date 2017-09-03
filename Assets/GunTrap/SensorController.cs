using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SensorController : MonoBehaviour {

	public GameObject button;


	private ButtonController bt;
	// Use this for initialization
	void Start () {
		bt  = button.GetComponent<ButtonController> ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//Debug.Log ("sensor triggered");
		if (!bt.isDeactivated && other.name == "Hans") {
			SceneManager.LoadScene ("FinishScene", LoadSceneMode.Single);
		}
	
	}
}
