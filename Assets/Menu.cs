using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Canvas exitCanvas;

    public Button btnStart;

    public Button btnExit;

    private Canvas menuUI;
	// Use this for initialization
	void Start ()
	{
	    menuUI = (Canvas) GetComponent<Canvas>();
        exitCanvas = (Canvas)GetComponent<Canvas>();
        exitCanvas.enabled = false;
	    menuUI.enabled = true;
	    Cursor.visible = menuUI.enabled;
        Cursor.lockState = CursorLockMode.Confined;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Wyjscie()
    {
        exitCanvas.enabled = true;
        btnExit.enabled = false;
        btnStart.enabled = false;
    }
    public void NieWyjscie()
    {
        exitCanvas.enabled = false;
        btnExit.enabled = true;
        btnStart.enabled = true;
    }

    public void StartButton()
    {
        menuUI.enabled = false;
    }
    public void TakWyjscie()
    {
        Application.Quit();
    }
}
