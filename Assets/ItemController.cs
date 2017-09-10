using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    private int seal;
    private int picture;
    private int document;
	private int key;


	// Use this for initialization
	void Start ()
	{
	    PlayerPrefs.SetInt("DocumentCount", 0);
        PlayerPrefs.SetInt("PictureCount", 0);
        PlayerPrefs.SetInt("SealCount", 0);
		PlayerPrefs.SetInt ("KeyCount", 0);
    }
	/// <summary>
    /// Metoda odpowiedzialna za zbieranie znajdziek z opóźnieniem 2 sec
    /// </summary>
    /// <param name="other">Nazwa obiektu</param>
	void OnTriggerEnter2D( Collider2D other )
    {
		if (this.gameObject.tag == "Document")
        {
			Debug.Log ("zebrano dokument");
			GetDocument ();
        }
		if(this.gameObject.tag == "Picture")
        {
			GetPicture ();
        }
		if (this.gameObject.tag == "Seal")
        {
			GetSeal ();
        }      
		if (this.gameObject.tag == "Key")
		{
			GetKey ();
		}  

		//jeżeli będą wszystkie to przejście do sceny końca gry
    }

    /// <summary>
    /// Metoda odpowiedzialna po zakończeniu kolizji za zniszczenie obiektu
    /// </summary>
    /// <param name="other">Nazwa kolidera</param>
//	void OnTriggerExit2D (Collider2D other)
//    {
//        Destroy(gameObject);
//    }
	//nie podobało mi się, że klucz był zebrany a cały czas leżał na mapie
	//teraz zbiera i od razu kasuje

    /// <summary>
    /// Metoda dodająca dokument
    /// </summary>
    void GetDocument()
    {
        document = PlayerPrefs.GetInt("DocumentCount");
        PlayerPrefs.SetInt("DocumentCount", ++document);
		Destroy(gameObject);
    }
    /// <summary>
    /// Metoda dodająca rysunek
    /// </summary>
    void GetPicture()
    {
        picture = PlayerPrefs.GetInt("PictureCount");
        PlayerPrefs.SetInt("PictureCount", ++picture);
		Destroy(gameObject);
    }
    /// <summary>
    /// Metoda dodająca pieczątkę
    /// </summary>
    void GetSeal()
    {
        seal = PlayerPrefs.GetInt("SealCount");
        PlayerPrefs.SetInt("SealCount", ++seal);
		Destroy(gameObject);
    }

	void GetKey()
	{
		key = PlayerPrefs.GetInt ("KeyCount");
		PlayerPrefs.SetInt("KeyCount", ++key);
		Debug.Log ("wzięto klucz");
		Destroy(gameObject);
	}
}
