using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour {

    public GameObject controll;
    public void quitGame()
    {
        Application.Quit();
    }

    public void startGame()
    {

        SceneManager.LoadScene("ControllerMapping");
    }

    public void controls()
    {
       //Debug.Log("Control is going on");
       controll.SetActive(true);
        this.gameObject.SetActive(false);        
    }
    public void outOfControl()
    {
        this.gameObject.SetActive(true);
        controll.SetActive(false);
        
    }


   // Use this for initialization
    void Start () {
        controll.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
