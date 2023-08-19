using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Height : MonoBehaviour
{
    public TMP_Text xPositionText;

    private void Update()
    {
        // Get the object's C position
        float xPosition = transform.position.x;

        // Update the Text UI element with the Y position
        xPositionText.text = "Distance: " + xPosition.ToString("F0"); // Display X
    }
}