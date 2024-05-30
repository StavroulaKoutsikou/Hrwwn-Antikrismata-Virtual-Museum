using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterAnswerMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject answerMenuUI; // Reference to the UI canvas to be shown/hidden
    public GameObject congratsCanvas; // Reference to the CONGRATS canvas
    public FPSController fpsController; // Reference to the FPSController script

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        // Activate the answer menu UI
        if (answerMenuUI != null)
        {
            Debug.Log("Activating answer menu UI");
            answerMenuUI.SetActive(true);
        }

        // Freeze the game by setting time scale to 0
        Time.timeScale = 0f;
        Debug.Log("Game paused");

        // Update the GameIsPaused flag
        GameIsPaused = true;

        // Disable player movement
        if (fpsController != null)
        {
            Debug.Log("Disabling player movement");
            fpsController.ToggleMovement(false); // Disable movement when pausing
        }

        // Show and unlock the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        // Deactivate the answer menu UI
        if (answerMenuUI != null)
        {
            Debug.Log("Deactivating answer menu UI");
            answerMenuUI.SetActive(false);
        }

        // Unfreeze the game by setting time scale back to 1
        Time.timeScale = 1f;
        Debug.Log("Game resumed");

        // Update the GameIsPaused flag
        GameIsPaused = false;

        // Enable player movement
        if (fpsController != null)
        {
            Debug.Log("Enabling player movement");
            fpsController.ToggleMovement(true); // Allow movement when resuming
        }

        // Hide and lock the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowCorrectAnswerCanvas()
    {
        // Deactivate the answer menu UI
        if (answerMenuUI != null)
        {
            answerMenuUI.SetActive(false);
        }

        // Activate the congrats canvas
        if (congratsCanvas != null)
        {
            congratsCanvas.SetActive(true);
        }

        // Optionally, keep the game paused or resume it based on your requirements
        // Time.timeScale = 0f; // Keep the game paused
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu()
    {
        Debug.Log("LoadMenu() method called.");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame() method called.");
        Application.Quit();
    }
}
