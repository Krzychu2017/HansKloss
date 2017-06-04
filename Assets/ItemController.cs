using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    private int seal;
    private int picture;
    private int document;


	// Use this for initialization
	void Start ()
	{
	    PlayerPrefs.SetInt("DocumentCount", 0);
        PlayerPrefs.SetInt("PictureCount", 0);
        PlayerPrefs.SetInt("SealCount", 0);
    }
	/// <summary>
    /// Metoda odpowiedzialna za zbieranie znajdziek z opóźnieniem 2 sec
    /// </summary>
    /// <param name="other">Nazwa obiektu</param>
    void OnCollisionEnter2D( Collision2D other )
    {
        if (other.gameObject.tag == "Document")
        {
			GetDocument ();
        }
        if(other.gameObject.tag == "Picture")
        {
			GetPicture ();
        }
        if (other.gameObject.tag == "Seal")
        {
			GetSeal ();
        }      
    }
    void OnCollisionStay2D( Collision2D other )
    {

    }
    /// <summary>
    /// Metoda odpowiedzialna po zakończeniu kolizji za zniszczenie obiektu
    /// </summary>
    /// <param name="other">Nazwa kolidera</param>
    void OnCollisionExit2D( Collision2D other )
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// Metoda dodająca dokument
    /// </summary>
    void GetDocument()
    {
        document = PlayerPrefs.GetInt("DocumentCount");
        PlayerPrefs.SetInt("DocumentCount", ++document);
    }
    /// <summary>
    /// Metoda dodająca rysunek
    /// </summary>
    void GetPicture()
    {
        picture = PlayerPrefs.GetInt("PictureCount");
        PlayerPrefs.SetInt("PictureCount", ++picture);
    }
    /// <summary>
    /// Metoda dodająca pieczątkę
    /// </summary>
    void GetSeal()
    {
        seal = PlayerPrefs.GetInt("SealCount");
        PlayerPrefs.SetInt("SealCount", ++seal);
    }
}
