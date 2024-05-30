using UnityEngine;

public class ClickInteraction : MonoBehaviour
{
    [SerializeField] private GameObject panelToOpen;
    [SerializeField] private EnterAnswerMenu enterAnswerMenu; // Reference to EnterAnswerMenu script

    private void Start()
    {
        // Hide the panel initially
        if (panelToOpen != null)
        {
            Debug.Log("Hiding panel initially");
            panelToOpen.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Object clicked");
        // Toggle the panel and pause/resume the game
        TogglePanel();
    }

    private void TogglePanel()
    {
        // Check if the panel is assigned
        if (panelToOpen != null && enterAnswerMenu != null)
        {
            bool isActive = !panelToOpen.activeSelf;
            Debug.Log("Toggling panel to " + (isActive ? "active" : "inactive"));
            panelToOpen.SetActive(isActive);

            // Pause or resume the game based on the panel's state
            if (isActive)
            {
                Debug.Log("Pausing game");
                enterAnswerMenu.Pause();
            }
            else
            {
                Debug.Log("Resuming game");
                enterAnswerMenu.Resume();
            }
        }
        else
        {
            Debug.LogWarning("Panel or EnterAnswerMenu reference is missing");
        }
    }
}
