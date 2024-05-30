using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject hintCanvasUI; // Reference to the HintCanvas
    public FPSController fpsController; // Reference to the FPSController script

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    void Pause()
    {
        // Activate the pause menu UI
        pauseMenuUI.SetActive(true);

        // Freeze the game by setting time scale to 0
        Time.timeScale = 0f;

        // Update the GameIsPaused flag
        GameIsPaused = true;

        // Disable player movement
        fpsController.ToggleMovement(false); // Disable movement when pausing

        // Show and unlock the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        // Deactivate the pause menu UI
        pauseMenuUI.SetActive(false);

        // Unfreeze the game by setting time scale back to 1
        Time.timeScale = 1f;

        // Update the GameIsPaused flag
        GameIsPaused = false;

        // Enable player movement
        fpsController.ToggleMovement(true); // Allow movement when resuming

        // Hide and lock the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadMenu()
    {
        Debug.Log("LoadMenu() method called."); // Add debug log
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame() method called."); // Add debug log
        Application.Quit();
    }

    public void LoadHintCanvas()
    {
        Debug.Log("LoadHintCanvas() method called."); // Add debug log
        hintCanvasUI.SetActive(true); // Activate the HintCanvas
    }
}
