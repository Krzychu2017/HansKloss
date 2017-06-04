using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{

    /// <summary>
    /// Metoda odpowioadająca za start kolizji. Po czasie 2 sec następuje zebranie jedzenia i odnowienie jego pojemniości.
    /// </summary>
    /// <param name="other">Obiekt kolizji</param>
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

    void GetFood()
    {
        PlayerPrefs.SetInt("FoodCount", 100);
    }
}
