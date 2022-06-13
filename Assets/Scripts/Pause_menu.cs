using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_menu : Entity
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject Can1;
    public GameObject Can2;
    public GameObject Can3;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if(GameIsPaused)
        //    {
        //        Resume();
        //    }
        //    else
        //    {
        //        Pause();
        //    }
        //}
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Can1.SetActive(true);
        Can2.SetActive(true);
        Can3.SetActive(true);


    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Can1.SetActive(false);
        Can2.SetActive(false);
        Can3.SetActive(false);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
