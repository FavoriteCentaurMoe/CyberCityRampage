using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gamePaused = false;

    public GameObject pauseMenuUI;

    public GameObject controll;

    public bool inControl = false;

    public float pauseStarted = 0f;

    // Use this for initialization
    void Start()
    {
        pauseMenuUI.SetActive(false);
        controll.SetActive(false);
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            if (inControl)
            {
                return;
            }
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gamePaused = true;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void controls()
    {
        inControl = true;
        Time.timeScale = 0f;
        controll.SetActive(true);
        pauseMenuUI.gameObject.SetActive(false);

    }

    public void outOfControl()
    {
        inControl = false;
        Time.timeScale = 1f;
        Debug.Log("Let peace reach your heart");
        controll.SetActive(false);
        //Resume();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start Button"))//Pause the game 
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }


    /*
     
            if(Input.GetButton("Start Button"))
        {
            LoadScenes("Jared things");
        }
    */
}