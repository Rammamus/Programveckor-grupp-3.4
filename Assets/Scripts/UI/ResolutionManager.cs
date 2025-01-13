using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ResolutionManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    void Start()
    {
        // Populate the dropdown with options
        PopulateDropdown();

        // Add listener for when the dropdown value changes
        resolutionDropdown.onValueChanged.AddListener(delegate { ChangeResolution(resolutionDropdown.value); });

        // Optionally, set the default value (e.g., Fullscreen)
        resolutionDropdown.value = 0; // Assuming 0 is Fullscreen
        ChangeResolution(resolutionDropdown.value);
    }

    private void PopulateDropdown()
    {
        // Clear existing options
        resolutionDropdown.ClearOptions();

        // Create a list of options
        var options = new List<string>
        {
            "Fullscreen",
            "Maximized Windowed",
            "Windowed"
        };

        // Add options to the dropdown
        resolutionDropdown.AddOptions(options);
    }

    public void ChangeResolution(int index)
    {
        switch (index)
        {
            case 0: // Fullscreen
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
                break;

            case 1: // Maximized Windowed
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
                break;

            case 2: // Windowed
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Screen.SetResolution(1280, 720, false); // Set your desired windowed resolution
                break;
        }
    }
}