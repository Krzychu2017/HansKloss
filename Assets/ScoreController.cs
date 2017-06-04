using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMesh FoodCount;
    public TextMesh DrinkCount;
    public TextMesh SealCount;
    public TextMesh PictureCount;
    public TextMesh DocumentCount;

    private int food;
    private int drink;
    private int seal;
    private int picture;
    private int document;
    // Use this for initialization
    void Start ()
	{
	    food = 100;
	    drink = 100;
	}

    void Awake()
    {
        InvokeRepeating("FoodUpdate",0.3f,0.3f);
        InvokeRepeating("DrinkUpdate", 0.3f, 0.3f);
    }
	// Update is called once per frame
	void Update ()
	{
	    food = PlayerPrefs.GetInt("FoodCount");
	    drink = PlayerPrefs.GetInt("DrinkCount");
	    seal = PlayerPrefs.GetInt("SealCount");
	    picture = PlayerPrefs.GetInt("PictureCount");
	    document = PlayerPrefs.GetInt("DocumentCount");
        FoodCount.text = food.ToString();
	    DrinkCount.text = drink.ToString();
	    SealCount.text = seal.ToString();
	    PictureCount.text = picture.ToString();
	    DocumentCount.text = document.ToString();
	}
    /// <summary>
    /// Metoda odpowiedzialna za zmniejszanie poziomu jedzenia
    /// </summary>
    void FoodUpdate()
    {
           PlayerPrefs.SetInt("FoodCount", --food);
    }
    /// <summary>
    /// Metoda odpowiedzialna za zmniejszanie licznika pragnienia
    /// </summary>
    void DrinkUpdate()
    {
        PlayerPrefs.SetInt("DrinkCount", --drink);
    }
}
