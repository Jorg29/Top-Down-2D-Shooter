using UnityEngine;
using UnityEngine.UI;

public class UnpauseButton : MonoBehaviour
{
    public GameObject pausePanel; // Reference to your pause panel
    
    private void Start()
    {
        // Ensure the button is interactable
        Button button = GetComponent<Button>();
        if (button != null)
        {
            // Add a click event listener to the button
            button.onClick.AddListener(UnpauseGame);
        }
    }

    // Method to unpause the game
    private void UnpauseGame()
    {
        // Resume the game and hide the pause panel
        Time.timeScale = 1f; // This restores normal time
        
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }
}
