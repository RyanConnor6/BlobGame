using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pause the game by setting time scale to 0
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1f; // Resume the game by setting time scale to 1
            Debug.Log("Game Resumed");
        }
    }
}