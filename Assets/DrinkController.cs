using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkController : MonoBehaviour {

    void OnCollisionEnter2D( Collision2D other )
    {
        
        Invoke("GetFood", 2.0f);
    }
    void OnCollisionStay2D( Collision2D other )
    {
        
    }

    void OnCollisionExit2D( Collision2D other )
    {
        
        Destroy(gameObject);
    }

    void GetDrink()
    {
        PlayerPrefs.SetInt("DrinkCount", 100);
    }
}
