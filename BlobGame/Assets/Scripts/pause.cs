using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject uiPanel;
    public Button resumeButton;
    public Button quitButton;

    private bool isPaused = false;

    private void Start()
    {
        // Set up button click listeners
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(Quit);
        pausePanel.SetActive(false);
        uiPanel.SetActive(true);
    }

    private void Update()
    {
        // Check for pause input (e.g., using the "Escape" key)
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

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        pausePanel.SetActive(true);
        uiPanel.SetActive(false);
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        pausePanel.SetActive(false);
        uiPanel.SetActive(true);
    }

    private void Quit()
    {
        Application.Quit(); // Quit the game (this is a simple example)
    }
}