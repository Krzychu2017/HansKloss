using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkController : MonoBehaviour {

	bool isTriggered = false;
	System.DateTime eventStartTime;
	/// <summary>
	/// Metoda odpowioadająca za start kolizji.
	/// </summary>
	/// <param name="other">Obiekt kolizji</param>
	void OnTriggerEnter2D( Collider2D other )
	{
		if (!isTriggered) {
			isTriggered = true;
			eventStartTime = System.DateTime.Now;
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		isTriggered = false;
	}

	void Update(){
		if (isTriggered && ((System.DateTime.Now - eventStartTime).TotalSeconds >= 1)) {
			GetDrink ();
			isTriggered = false;
		}

	}

    void GetDrink()
    {
        PlayerPrefs.SetInt("DrinkCount", 100);
		Destroy(gameObject);
    }
}
