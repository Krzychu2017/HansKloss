﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	public Text FoodCount;
	public Text DrinkCount;
	public Text SealCount;
	public Text PictureCount;
	public Text DocumentCount;
	public Text KeyCount;

    private int food;
    private int drink;
    private int seal;
    private int picture;
    private int document;
	private int key;
    // Use this for initialization
    void Start ()
	{
	    PlayerPrefs.SetInt("FoodCount", 100);
	    PlayerPrefs.SetInt("DrinkCount", 100);
    }

    void Awake()
    {
        InvokeRepeating("FoodUpdate",1f,1f);
        InvokeRepeating("DrinkUpdate", 1.2f, 1.2f);
    }
	// Update is called once per frame
	void Update ()
	{
	    food = PlayerPrefs.GetInt("FoodCount");
	    drink = PlayerPrefs.GetInt("DrinkCount");
	    seal = PlayerPrefs.GetInt("SealCount");
	    picture = PlayerPrefs.GetInt("PictureCount");
	    document = PlayerPrefs.GetInt("DocumentCount");
		key = PlayerPrefs.GetInt ("KeyCount");
        FoodCount.text = food.ToString();
	    DrinkCount.text = drink.ToString();
	    SealCount.text = seal.ToString();
	    PictureCount.text = picture.ToString();
	    DocumentCount.text = document.ToString();
		KeyCount.text = key.ToString ();
	    if (food <= 0)
	    {
	        SceneManager.LoadScene(2);
        }
	    if (drink <= 0)
	    {
	        SceneManager.LoadScene(2);
	    }
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
