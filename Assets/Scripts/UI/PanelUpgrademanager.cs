using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class PanelUpgrademanager : MonoBehaviour
{
    public List<GameObject> item; // List of button prefabs or items
    public Transform panel; // Parent panel for buttons

    // Update is called once per frame
    public void OnEnable()
    {
        // Activate the panel
        panel.gameObject.SetActive(true);

        // Deactivate all buttons in the panel
        foreach (Transform child in panel)
        {
            child.gameObject.SetActive(false);
        }

        // Select 3 random items from the list
        System.Random random = new System.Random();
        var selectedItems = item.OrderBy(x => random.Next()).Take(3).ToList();

        // Activate the buttons and set their text
        for (int i = 0; i < selectedItems.Count; i++)
        {
            GameObject button = selectedItems[i];
            button.SetActive(true); // Activate the button

            // Assuming the button has a Text component as a child
            Text buttonText = button.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.text = "Upgrade " + (i + 1); // Set button text
            }

            // Optionally, set up button click events here
            Button buttonComponent = button.GetComponent<Button>();
            if (buttonComponent != null)
            {
                int index = i; // Capture the index for the event
                buttonComponent.onClick.AddListener(() => OnUpgradeButtonClicked(index));
            }
        }
    }

    private void OnUpgradeButtonClicked(int index)
    {
        // Handle the button click event
        Debug.Log("Button " + index + " clicked!");
        // Add your logic for what happens when the button is clicked
    }
}