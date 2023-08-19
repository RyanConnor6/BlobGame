using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Height : MonoBehaviour
{
    public TMP_Text yPositionText; // Reference to the Text UI element

    private void Update()
    {
        // Get the object's Y position
        float yPosition = transform.position.y + 3.5f;

        // Update the Text UI element with the Y position
        yPositionText.text = "Height: " + yPosition.ToString("F0"); // Display Y position with 2 decimal places
    }
}