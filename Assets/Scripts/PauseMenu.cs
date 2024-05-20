using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadSettings()
    {
        // Activate the settings menu or load the settings scene
        SceneManager.LoadScene("SettingsScene");
    }

    public void LoadMainMenu()
    {
        // Resume time scale before loading the main menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main"); // Replace with your main menu scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
