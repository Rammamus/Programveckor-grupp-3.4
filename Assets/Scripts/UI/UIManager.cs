using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject settingsButton;
    public GameObject backButton;
    public GameObject resumeButton;
    public GameObject quitButton;

    [Header("References")]
    public GameObject ui; // Main UI
    public GameObject pauseMenu; // Pause menu
    public GameObject settingsMenu; // Settings menu

    public bool isSettingsActive;
    public bool isPaused;

    private void Start()
    {
        isSettingsActive = false;
        isPaused = false;

        settingsMenu.SetActive(isSettingsActive);
        pauseMenu.SetActive(false);
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingsActive)
            {
                Back(); // Close settings if active
            }
            else if (isPaused)
            {
                Resume(); // Resume the game if paused
            }
            else
            {
                PauseGame(); // Pause the game if not paused
            }
        }
    }

    #region buttons

    public void Back()
    {
        if (isSettingsActive && SceneManager.GetActiveScene().name == ("MainMenu"))
        {
            isSettingsActive = false;
            settingsMenu.SetActive(isSettingsActive);
            
        }
        else if (isSettingsActive)
        {
            isSettingsActive = false;
            settingsMenu.SetActive(isSettingsActive);
            pauseMenu.SetActive(true); // Show the pause menu when going back from settings

        }
    }

    public void Resume()
    {
        if (isPaused)
        {
            Time.timeScale = 1; // Resume the game

            pauseMenu.SetActive(false); // Hide the pause menu
            

            isPaused = false;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
#else
        Application.Quit(); // Quit the application
#endif
        Debug.Log("Quit the Game");
    }

    #endregion

    public void ActivateSettings()
    {
        isSettingsActive = true;

        settingsMenu.SetActive(isSettingsActive); // Show settings menu
        pauseMenu.SetActive(false); // Hide pause menu
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // Pause the game
        isPaused = true; // Update the pause state

        
        pauseMenu.SetActive(true); // Show the pause menu
        
    }

    #region fullscreen dropdown

    public void ToggleFullScreen()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }

    public void ToggleMaximizedWindowed()
    {
        Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
    }

    public void ToggleWindowed()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }

    #endregion
}