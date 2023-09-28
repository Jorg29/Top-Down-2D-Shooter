using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;

    private void Start()
    {
        // Ensure the pause panel is initially hidden
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // Function to toggle pause state
    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game and show the pause panel
            Time.timeScale = 0f; // This stops time in the game
            if (pausePanel != null)
            {
                pausePanel.SetActive(true);
            }
        }
        else
        {
            // Resume the game and hide the pause panel
            Time.timeScale = 1f; // This restores normal time
            if (pausePanel != null)
            {
                pausePanel.SetActive(false);
            }
        }
    }

    // Function to show the pause panel
    public void ShowPausePanel()
    {
        if (!isPaused && pausePanel != null)
        {
            isPaused = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
    }
}
