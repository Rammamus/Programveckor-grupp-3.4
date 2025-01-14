using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject settingsUI;
    public Button settingsButton;

    private void Start()
    {
        settingsButton.onClick.AddListener(SettingsMenu);
        settingsButton.onClick.AddListener(HideSettings);
    }

    public void SettingsMenu()
    {
        mainUI.SetActive(false);
    }

    public void HideSettings()
    {
        settingsUI.SetActive(false);
        mainUI.SetActive(true);
    }



    

    
}
