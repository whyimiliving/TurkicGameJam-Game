//From GPT with love
using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes
using UnityEngine.UI; // For Button interactions

public class PausePanel : MonoBehaviour
{
    // Reference to the GameObject that controls the pause panel
    public GameObject pausePanel;

    // Flag to track if the game is paused
    private bool isPaused = false;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        // Check if we press the 'Escape' key to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // Function to toggle pause state
    void TogglePause()
    {
        isPaused = !isPaused;

        // If game is paused, stop the time
        if (isPaused)
        {
            Time.timeScale = 0;  // Stop the game
        }
        else
        {
            Time.timeScale = 1;  // Resume the game
        }

        // Activate or deactivate the pause panel based on isPaused
        pausePanel.SetActive(isPaused);
    }

    // Function to check if the GameObject is active
    public void CheckPausePanelStatus()
    {
        // Check if the pause panel is active
        if (!pausePanel.activeInHierarchy)
        {
            // If inactive, stop the game
            Time.timeScale = 0;
        }
        else
        {
            // If active, continue the game
            Time.timeScale = 1;
        }
    }

    // Continue the game (called when Continue button is pressed)
    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Resume the game
        pausePanel.SetActive(false); // Hide the pause panel
    }

    // Quit the application (called when Quit button is pressed)
    public void QuitApplication()
    {
        Application.Quit();
    }
}

