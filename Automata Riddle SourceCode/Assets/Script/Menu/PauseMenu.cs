using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (GameisPaused)
        //    {
        //        resume();
        //    }
        //    else
        //    {
        //        pause();
        //    }
        //}
    }
    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
    public void quit()
    {
        resume();
        SceneManager.LoadScene("TitleScreen");
    }
}
