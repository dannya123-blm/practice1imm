using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // This method will be called when the Start button is pressed
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("Level_01"); // Updated to load the "gameOne" scene
    }

    // This method will be called when the Settings button is pressed
    public void OnSettingsButtonPressed()
    {
        SceneManager.LoadScene("SettingsScene"); // Replace "SettingsScene" with the name of your settings scene
    }

    // This method will be called when the Quit button is pressed
    public void OnQuitButtonPressed()
    {
        Application.Quit(); // This will quit the application
#if UNITY_EDITOR
        // If you are running in the Unity editor, stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
